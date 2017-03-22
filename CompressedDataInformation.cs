using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7zipCompression
{
    public class CompressedDataInformation : IComparable<CompressedDataInformation>
    {
        public CompressedDataInformation( string extension, float fileCompressionRatio, double fileCompressionTime, string fileCompressionMethod, string fileArchiveFormat, string fileCompressSpeed)
        {
            _fileCompressionRatio = fileCompressionRatio;
            _fileCompressionTime = fileCompressionTime;
            _fileCompressionMethod = fileCompressionMethod;
            _fileArchiveFormat = fileArchiveFormat;
            _fileCompressSpeed = fileCompressSpeed;
            _extension = extension;

        }
        private string _extension;
        private string _folderName;
        private float _fileCompressionRatio;
        private double _fileCompressionTime;
        private string _fileCompressionMethod;
        private string _fileArchiveFormat;
        private string _fileCompressSpeed;

        public float FileCompressionRatio
        {
            get { return _fileCompressionRatio; }

            set { _fileCompressionRatio = value; }
        }

        public string FileType
        {
            get { return _extension; }

            set { _extension = value; }
        }

        public double FileCompressionTime
        {
            get { return _fileCompressionTime; }

            set { _fileCompressionTime = value; }
        }

        public string FileCompressionMethod
        {
            get { return _fileCompressionMethod; }

            set { _fileCompressionMethod = value; }
        }

        public string FileArchiveFormat
        {
            get { return _fileArchiveFormat; }

            set { _fileArchiveFormat = value; }
        }

        public string FileCompressSpeed
        {
            get { return _fileCompressSpeed; }

            set { _fileCompressSpeed = value; }
        }

        public int CompareTo(CompressedDataInformation obj)
        {
            if (obj == null) return 1;
            if (this.FileCompressionRatio > obj.FileCompressionRatio) return -1;
            if (this.FileCompressionRatio > obj.FileCompressionRatio) return 1;
            return 0;
        }
    }
}
