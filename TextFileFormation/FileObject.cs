namespace TextFileFormation
{
    internal class FileObject
    {
        /// <summary>
        /// Class for the files.
        /// </summary>
        public string Name { get; set; }

        public string[] Data { get; set; }
        public int Result { get; set; } = 0;
    }
}