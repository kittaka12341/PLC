namespace ServerSimulator.Models
{
    public class ServerSimData
    {
        public int BitSize { get; set; }
        public int ByteSize { get; set; }

        public byte[] OutData { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="registerNum">レジスタ点数</param>
        /// <remarks>レジスタ1点=16bit</remarks>
        public ServerSimData(int registerNum)
        {
            BitSize = registerNum * 16;
            ByteSize = registerNum * 2;
        }
    }
}
