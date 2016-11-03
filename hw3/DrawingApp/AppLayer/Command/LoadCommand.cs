using System;
using System.IO;
using Amazon;
using Amazon.S3;

namespace AppLayer.Command
{
    public class LoadCommand : Command
    {
        private readonly string _filename;

        internal LoadCommand() { }
        internal LoadCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                _filename = commandParameters[0] as string;
        }

        public override void Execute()
        {
            IAmazonS3 s3Client = new AmazonS3Client();
            Stream s = s3Client.GetObjectStream("cs5700-1", _filename, null);
            TargetDrawing?.LoadFromStream(s);
            s.Close();
            CommandHistory.Instance.Clear();

            //if (File.Exists(_filename))
            //{
            //    StreamReader reader = new StreamReader(_filename);
            //    TargetDrawing?.LoadFromStream(reader.BaseStream);
            //    reader.Close();
            //    CommandHistory.Instance.Clear();
            //}
        }

        public override string ToString()
        {
            return "";
        }

        public override void Undo()
        {
            
        }
    }
}
