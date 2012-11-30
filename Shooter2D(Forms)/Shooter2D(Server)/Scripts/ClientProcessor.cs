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
    public class ClientProcessor
    {
        public int id
        {
            get { return _id; }
            set { }
        }

        GameState gameState;
        TcpClient client;
        int _id;
        StreamReader reader = null;
        StreamWriter writer = null;
        

        public ClientProcessor(GameState gameState, int id, TcpClient client)
        {
            this.gameState = gameState;
            this._id = id;
            this.client = client;

            NetworkStream stream = client.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream);
        }

        public void run()
        {

            String data = null;

            // envia id para cliente
            send("Jogando com " + id);

            // faz leitura de uma linha do cliente
            data = reader.ReadLine();

            // Loop to receive all the data sent by the client. 
            while (data != null)
            {
                Console.WriteLine(_id + ": Recebido = " + data);

                data = reader.ReadLine();
            }

            // Shutdown and end connection
            client.Close();

        }

        void send(String text)
        {
            Console.WriteLine(_id + " send: [" + text + "]");

            writer.Write(text);
            writer.WriteLine();
            writer.Flush();
        }

        public void ReactToMessage(string data)
        {
            try
            {
                //manda instanciar
                if (data.StartsWith("Instanciar"))
                {
                    if (!imagens[idTemp].instanciado)
                    {
                        Instanciar();
                        imagens[idTemp].instanciado = true;
                    }
                }

                // Recebe o id
                if (data.StartsWith("id:"))
                {
                    string dataTemp = data.Replace("id:", "");
                    idTemp = CalculoString(dataTemp);
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].id = idTemp;
                }

                //Recebe o nome
                if (data.StartsWith("nome:"))
                {
                    nomeTemp = data.Replace("nome:", "");
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].nome = nomeTemp;
                }

                //Recebe as posicoes
                if (data.StartsWith("posicaoX:"))
                {
                    posicaoTemp.X = CalculoString(data.Replace("posicaoX:", ""));
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].posicao.X = posicaoTemp.X;
                }

                if (data.StartsWith("posicaoY:"))
                {
                    posicaoTemp.Y = CalculoString(data.Replace("posicaoY:", ""));
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].posicao.Y = posicaoTemp.Y;
                }

                //Recebe a rotacao
                if (data.StartsWith("rotacao:"))
                {
                    rotacaoTemp = CalculoString(data.Replace("rotacao:", ""));
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].rotacao = rotacaoTemp;
                }

                //Recebe a largura e altura
                if (data.StartsWith("largura:"))
                {
                    larguraTemp = CalculoString(data.Replace("largura:", ""));
                    if (imagens[idTemp].instanciado)
                        imagens[idTemp].largura = larguraTemp;
                }

                if (data.StartsWith("altura:"))
                {
                    alturaTemp = CalculoString(data.Replace("altura:", ""));
                    if (!imagens[idTemp].instanciado)
                        imagens[idTemp].altura = alturaTemp;
                }

                //Recebe que imagem ele é
                if (data.StartsWith("imagem:"))
                    imagemTemp = data.Replace("imagem:", "");

            }
            catch { }
        }
    }
}
