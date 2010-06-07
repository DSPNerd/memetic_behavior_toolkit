﻿using System;
using System.Drawing;
using System.Windows.Forms;
using CustomMemes;
using MemeLibrary;

namespace MemeController
{
    public partial class Form1 : Form
    {
        private WanderMeme _wander;
        private int _roomCounter;
        
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);


        public Form1()
        {
            InitializeComponent();

            MarkAllRoomsUnoccupied();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = false;
            btnStop.Enabled = true;

            _wander = new WanderMeme();

            _wander.OnMemeEventHasFired += _wander_OnMemeEventHasFired;
        }

        void _wander_OnMemeEventHasFired(Meme meme, MemeEvent memeEvent)
        {
            string msg = meme.Name + " has fired." + Environment.NewLine;
            SetText(msg);
            ProcessRoom();
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtLog.InvokeRequired)
            {
                var d = new SetTextCallback(SetText);
                Invoke(d, new object[] { text });
            }
            else
            {
                txtLog.Text += text;
                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.SelectionLength = 0;
                txtLog.ScrollToCaret();
            }
        }

        private void ProcessRoom()
        {
            _roomCounter++;

            switch (_roomCounter)
            {
                case 1:
                    MarkRoomOccupied(pRoom1);
                    SetText("Wandering over to room 1..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom10);
                    break;
                case 2:
                    MarkRoomOccupied(pRoom2);
                    SetText("Wandering over to room 2..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom1);
                    break;
                case 3:
                    MarkRoomOccupied(pRoom3);
                    SetText("Wandering over to room 3..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom2);
                    break;
                case 4:
                    MarkRoomOccupied(pRoom4);
                    SetText("Wandering over to room 4..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom3);
                    break;
                case 5:
                    MarkRoomOccupied(pRoom5);
                    SetText("Wandering over to room 5..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom4);
                    break;
                case 6:
                    MarkRoomOccupied(pRoom6);
                    SetText("Wandering over to room 6..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom5);
                    break;
                case 7:
                    MarkRoomOccupied(pRoom7);
                    SetText("Wandering over to room 7..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom6);
                    break;
                case 8:
                    MarkRoomOccupied(pRoom8);
                    SetText("Wandering over to room 8..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom7);
                    break;
                case 9:
                    MarkRoomOccupied(pRoom9);
                    SetText("Wandering over to room 9..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom8);
                    break;
                case 10:
                    MarkRoomOccupied(pRoom10);
                    SetText("Wandering over to room 10..." + Environment.NewLine);
                    MarkRoomEmpty(pRoom9);
                    break;
            }

            if (_roomCounter > 10)
            {
                _roomCounter = 0;
            }
        }

        private void MarkRoomOccupied(Panel room)
        {
            room.BackColor = Color.Firebrick;
        }

        private void MarkRoomEmpty(Panel room)
        {
            room.BackColor = Color.SkyBlue;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnLoad.Enabled = true;
            btnStop.Enabled = false;

            _wander.Stop();
            SetText("Whew, time to rest!" + Environment.NewLine);
        }

        private void MarkAllRoomsUnoccupied()
        {
            MarkRoomEmpty(pRoom1);
            MarkRoomEmpty(pRoom2);
            MarkRoomEmpty(pRoom3);
            MarkRoomEmpty(pRoom4);
            MarkRoomEmpty(pRoom5);
            MarkRoomEmpty(pRoom6);
            MarkRoomEmpty(pRoom7);
            MarkRoomEmpty(pRoom8);
            MarkRoomEmpty(pRoom9);
            MarkRoomEmpty(pRoom10);
        }
    }
}
