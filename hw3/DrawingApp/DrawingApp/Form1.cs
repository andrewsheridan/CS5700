using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLayer.Command;
using AppLayer.DrawingComponents;
using System.Globalization;
using Amazon;
using Amazon.S3;

namespace DrawingApp
{
    public partial class Form1 : Form
    {
        private readonly Drawing _drawing;
        private readonly CommandFactory _commandFactory;
        private string _currentImageResource;
        private float _currentScale = 1;
        private List<Command> History = CommandHistory.Instance;

        private enum PossibleModes
        {
            None,
            ImageDrawing,
            Selection,
            Movement
        };

        private PossibleModes _mode = PossibleModes.None;

        private Bitmap _imageBuffer;
        private Graphics _imageBufferGraphics;
        private Graphics _panelGraphics;

        public Form1()
        {
            InitializeComponent();

            _drawing = new Drawing(drawingPanel.Size);
            _commandFactory = new CommandFactory() { TargetDrawing = _drawing };
            _drawing.Factory = new ImageFactory()
            {
                ResourceNamePattern = @"DrawingApp.Graphics.{0}.png",
                ReferenceType = typeof(Program)
            };

            this.Controls.Add(saveLoadPanel);
        }

        private void LoadFiles()
        {
            IAmazonS3 s3Client = new AmazonS3Client();
            IList<string> objectKeys = s3Client.GetAllObjectKeys("cs5700-1", null, null);
            foreach (string key in objectKeys)
            {
                loadFileComboBox.Items.Add(key);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadFiles();
            ComputeDrawingPanelSize();
            refreshTimer.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            DisplayDrawing(); 
        }

        private void DisplayDrawing()
        {
            if (_imageBuffer == null)
            {
                _imageBuffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                _imageBufferGraphics = Graphics.FromImage(_imageBuffer);
                _panelGraphics = drawingPanel.CreateGraphics();
            }

            if (_drawing.Draw(_imageBufferGraphics))
                _panelGraphics.DrawImageUnscaled(_imageBuffer, 0, 0);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            _commandFactory.Create("new").Execute();
        }

        private void ClearOtherSelectedTools(ToolStripButton ignoreItem)
        {
            foreach (ToolStripItem item in drawingToolStrip.Items)
            {
                ToolStripButton toolButton = item as ToolStripButton;
                if (toolButton != null && item != ignoreItem && toolButton.Checked)
                    toolButton.Checked = false;
            }
        }

        private void pointerButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
            {
                _mode = PossibleModes.Selection;
                _currentImageResource = string.Empty;
            }
            else
            {
                _commandFactory.Create("deselect").Execute();
                _mode = PossibleModes.None;
            }
        }

        private void imageButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);
            _drawing.ClearSelected();

            if (button != null && button.Checked)
                _currentImageResource = button.Text;
            else
                _currentImageResource = string.Empty;

            _mode = (_currentImageResource != string.Empty) ? PossibleModes.ImageDrawing : PossibleModes.None;
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mode == PossibleModes.ImageDrawing)
            {
                if (!string.IsNullOrWhiteSpace(_currentImageResource))
                    _commandFactory.Create("add", _currentImageResource, e.Location.X, e.Location.Y, _currentScale)
                        .Execute();
            }
            else if (_mode == PossibleModes.Selection)
                _commandFactory.Create("select", e.Location.X, e.Location.Y).Execute();
            else if (_mode == PossibleModes.Movement)
                _commandFactory.Create("move", e.X, e.Y).Execute();
        }

        private float ConvertToFloat(string text, float min, float max, float defaultValue)
        {
            float result = defaultValue;
            if (!string.IsNullOrWhiteSpace(text))
            {
                if (!float.TryParse(text, out result))
                    result = defaultValue;
                else
                    result = Math.Max(min, Math.Min(max, result));
            }
            return result;
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            //OpenFileDialog dialog = new OpenFileDialog
            //{
            //    CheckFileExists = true,
            //    DefaultExt = "json",
            //    Multiselect = false,
            //    RestoreDirectory = true,
            //    Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            //};

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    _commandFactory.Create("load", dialog.FileName).Execute();
            //}
            showLoadFileDialog();
        }

        private void showLoadFileDialog()
        {
            saveLoadLabel.Text = "Load from Cloud";
            drawingPanel.Hide();

            saveLoadButton.Text = "Load";
            saveFileNameTextBox.Hide();
            loadFileComboBox.Show();
            saveFileNameTextBox.Hide();

            saveLoadPanel.Show();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dialog = new SaveFileDialog
            //{
            //    DefaultExt = "json",
            //    RestoreDirectory = true,
            //    Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            //};
            showSaveDialog();
        }

        private void showSaveDialog()
        {
            drawingPanel.Hide();

            saveLoadLabel.Text = "Save to Cloud";
            saveLoadButton.Text = "Save";
            saveFileNameTextBox.Show();
            loadFileComboBox.Hide();

            saveLoadPanel.Show();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
        }

        private void ComputeDrawingPanelSize()
        {
            int width = Width - drawingToolStrip.Width;
            int height = Height - fileToolStrip.Height;

            drawingPanel.Size = new Size(width, height);
            drawingPanel.Location = new Point(drawingToolStrip.Width, fileToolStrip.Height);

            _imageBuffer = null;
            if (_drawing != null)
                _drawing.IsDirty = true;
        }

        private void scale_Leave(object sender, EventArgs e)
        {
            _currentScale = ConvertToFloat(scale.Text, 0.01F, 10.0F, 1);
            scale.Text = _currentScale.ToString(CultureInfo.InvariantCulture);
            _commandFactory.Create("scale", _currentScale).Execute();
        }

        private void scale_TextChanged(object sender, EventArgs e)
        {
            _currentScale = ConvertToFloat(scale.Text, 0.01F, 10.0F, 1);
        }

        private void scale_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                _currentScale = ConvertToFloat(scale.Text, 0.01F, 10.0F, 1);
                scale.Text = _currentScale.ToString(CultureInfo.InvariantCulture);
                _commandFactory.Create("scale", _currentScale).Execute();
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
            {
                _mode = PossibleModes.Movement;
                _currentImageResource = string.Empty;
            }
            else
            {
                _commandFactory.Create("deselect").Execute();
                _mode = PossibleModes.None;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null)
            {
                _currentImageResource = string.Empty;
                _commandFactory.Create("remove").Execute();
            }
        }

        private void copyToolstripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null)
            {
                _currentImageResource = string.Empty;
                _commandFactory.Create("copy").Execute();
            }
        }

        private void undoToolstripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null)
            {
                _currentImageResource = string.Empty;
                if(History.Count > 0)
                {
                    Command c = History[History.Count - 1];
                    History.RemoveAt(History.Count - 1);
                    c.Undo();
                }
            }
        }



        private void blankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawing.SetBackground(Drawing.BackgroundType.blank);
        }

        private void graveyardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawing.SetBackground(Drawing.BackgroundType.graveyard);
        }

        private void hauntedHouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _drawing.SetBackground(Drawing.BackgroundType.hauntedHouse);
        }

        private void saveLoadButton_Click(object sender, EventArgs e)
        {
            if(saveLoadButton.Text.ToLower() == "save")
            {
                string fileName = saveFileNameTextBox.Text;
                if (fileName != "")
                {
                    if (!fileName.Contains(".json"))
                    {
                        fileName += ".json";

                    }
                    _commandFactory.Create("save", fileName).Execute();
                    LoadFiles();
                }
            }
            else
            {
                _commandFactory.Create("load", (string)loadFileComboBox.SelectedItem).Execute();
            }
            saveLoadPanel.Hide();
            drawingPanel.Show();
        }

        private void cancelSaveLoadButton_Click(object sender, EventArgs e)
        {
            saveLoadPanel.Hide();
            drawingPanel.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.N:
                    _commandFactory.Create("new").Execute();
                    break;
                case Keys.S:
                    selectToolStripButton.Checked = true;
                    ClearOtherSelectedTools(selectToolStripButton);
                    break;
                case Keys.M:
                    moveButton.Checked = true;
                    ClearOtherSelectedTools(moveButton);
                    break;
                case Keys.C:
                    _commandFactory.Create("copy").Execute();
                    break;
                case Keys.U:
                    _currentImageResource = string.Empty;
                    if (History.Count > 0)
                    {
                        Command c = History[History.Count - 1];
                        History.RemoveAt(History.Count - 1);
                        c.Undo();
                    }
                    break;
                case Keys.R:
                    _commandFactory.Create("remove").Execute();
                    break;
                case Keys.L:
                    showLoadFileDialog();
                    break;
            }
        }
    }
}