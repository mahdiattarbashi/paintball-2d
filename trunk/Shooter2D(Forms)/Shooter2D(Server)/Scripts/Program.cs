using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Shooter2D_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener ouvidorNet = null;
            int port = 50000;
            GameState gameState = new GameState();
            
            bool working = true;

            try
            {
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                ouvidorNet = new TcpListener(localAddr, port);
                ouvidorNet.Start();

                while (working)
                {
                    if (!gameState.isReady())
                    {
                        Console.WriteLine("Aguardando conexoes");

                        // aguarda nova conexao
                        TcpClient client = ouvidorNet.AcceptTcpClient();
                        gameState.addPlayer(client);
                    }
                    else
                    {
                        // o jogo comecou
                        gameState.play();
                    }
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("Erro de rede: {0}", e);
            }
            finally
            {
                ouvidorNet.Stop();
            }

        }
    }
}
