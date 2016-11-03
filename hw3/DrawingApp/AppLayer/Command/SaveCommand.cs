using System;
using System.IO;
using System.Runtime.Serialization.Json;
using AppLayer.DrawingComponents;
using Amazon.S3;
using Amazon;
using Amazon.S3.Model;

namespace AppLayer.Command
{
    public class SaveCommand : Command
    {
        private readonly string _filename;
        internal SaveCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                _filename = commandParameters[0] as string;
        }

        public override void Execute()
        {
            MemoryStream stream = new MemoryStream();
            TargetDrawing?.SaveToStream(stream);

            IAmazonS3 s3Client = new AmazonS3Client();
            s3Client.UploadObjectFromStream("cs5700-1", _filename, stream, null);

            stream.Close();
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
