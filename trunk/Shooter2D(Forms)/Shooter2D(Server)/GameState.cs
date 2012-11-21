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
    public class GameState
    {
        const int MAX_PLAYERS = 2;
        
        int lastId = 0;
        ClientProcessor[] players;
        
        bool ready = false;
        //int turn = 0;

        public bool isReady()
        {
            return ready;
        }

        public GameState()
        {
            players = new ClientProcessor[MAX_PLAYERS];
        }

        public void addPlayer(TcpClient client)
        {
            if (ready)
            {
                disconectPlayer(client);
            }

            // gera identificador do cliente
            int id = nextId();
            Console.WriteLine("Novo cliente id = " + id);

            // cria novo thread para cuidar do novo cliente
            players[id] = new ClientProcessor(this, id, client);
            Thread thread = new Thread(players[id].run);
            thread.Start();

            if (id + 1 >= MAX_PLAYERS)
            {
                ready = true;
            }

        }

        private void disconectPlayer(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write("server cheio");
            writer.WriteLine();
            writer.Flush();

            client.Close();
        }

        public int nextId()
        {
            return lastId++;
        }

        bool waiting = false;

        public void play()
        {
            if (!waiting)
            {
                readyToPlay();
                waiting = true;
            }

        }

        public void readyToPlay() 
        {
        
        }
    }
}
