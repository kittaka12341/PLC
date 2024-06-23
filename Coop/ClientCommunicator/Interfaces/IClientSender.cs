using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientCommunicator.Interfaces
{
    public interface IClientSender
    {
        /// <summary>
        /// サーバへ接続
        /// </summary>
        /// <param name="token">キャンセル用トークン</param>
        /// <returns>true:成功、false:失敗</returns>
        public bool ConnectAsync(CancellationToken token);

        /// <summary>
        /// サーバへコマンド送信
        /// </summary>
        /// <param name="sendBytes">送信バイト</param>
        /// <returns>コマンド応答</returns>
        public byte[] Write(byte[] sendBytes);

        /// <summary>
        /// サーバへの接続を破棄
        /// </summary>
        public void Dispose();
    }
}
