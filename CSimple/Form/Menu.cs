﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZBase.Cheats;
using ZBase.Classes;
using ZBase.Utilities;
using CSimple;
using CSimple.SDK;
using CSimple.SDK.Structs;
using static CSimple.SDK.Memory;
using static CSimple.SDK.Offsets;
namespace ZBase
{
    public partial class Menu : Form
    {
        #region ZBase Menu
        public Menu()
        {
            InitializeComponent();
            if (Main.RunStartup())
            {
                OffsetUpdater.UpdateOffsets();
                #region Start Threads
                // found the process and everything, lets start our cheats in a new thread
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    CheckMenu();
                }).Start();

                Tools.InitializeGlobals();

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Bunnyhop.Run();
                }).Start();

                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    Visuals v = new Visuals();
                    v.Initialize();
                    v.Run();
                }).Start();
                Thread Updater = new Thread(MainLoop);
                Updater.IsBackground = true;
                Updater.Start();
                #endregion
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            TopMost = true; // make this hover over the game, can remove if you want
        }
        public static void MainLoop()
        {
            while (true)
            {
                int GlowBase = ReadMemory<int>((int)g_pClient + dwGlowObjectManager);
                int Local = ReadMemory<int>((int)g_pClient + dwLocalPlayer);
                int LocalTeam = ReadMemory<int>(Local + m_iTeamNum);
                int LocalFlash = ReadMemory<int>(Local + m_flFlashMaxAlpha);
                int LocalFov = ReadMemory<int>(Local + (m_iFOVStart - 4));
                int LocalScope = ReadMemory<int>(Local + m_bIsScoped);
                GlowObject GlowObj = new GlowObject();
                #region EntityLoop
                for (var i = 0; i <= 64; i++)
                {
                    int EntBase = ReadMemory<int>((int)g_pClient + dwEntityList + i * 0x10);
                    if (EntBase == 0) continue;
                    int Dormant = ReadMemory<int>(EntBase + m_bDormant);
                    if (Dormant == 1) continue;
                    int Team = ReadMemory<int>(EntBase + m_iTeamNum);
                    int GlowIndex = ReadMemory<int>(EntBase + m_iGlowIndex);
                    int Spotted = ReadMemory<int>(EntBase + m_bSpotted);
                    bool Visible = IsVisible(Local, EntBase);
                    var M8 = (Team == LocalTeam);
                    if (Globals.bRadar)
                        if (Spotted == 0 && !M8) WriteMemory<int>(EntBase + m_bSpotted, 1);
                    if (Globals.bGlow)
                    {
                        GlowObj = ReadMemory<GlowObject>(GlowBase + GlowIndex * 0x38);
                        if (Globals.iGlowMode == 1 && M8) continue;
                        if (Globals.iGlowMode == 2 && !Visible) continue;
                        GlowObj.r = M8 ? 0.0f : 1.0f;
                        GlowObj.g = M8 ? 1.0f : 0.0f;
                        GlowObj.b = 0.0f;
                        GlowObj.a = 0.7f;
                        GlowObj.m_bRenderWhenOccluded = true;
                        GlowObj.m_bRenderWhenUnoccluded = false;
                        GlowObj.m_bFullBloom = false;
                        WriteMemory<GlowObject>(GlowBase + GlowIndex * 0x38, GlowObj);
                    }
                    #region Trigger Bot
                    var iCrosshairIndex = ReadMemory<int>(EntBase + m_iCrosshairId);
                    var iCrossBase = ReadMemory<int>((int)g_pClient + dwEntityList + (iCrosshairIndex - 1) * 0x10);
                    var iCrossTeam = ReadMemory<int>(iCrossBase + m_iTeamNum);
                    var HoldingKey = GetAsyncKeyState(Globals.iTriggerKey);
                    var M8onCross = (iCrossTeam == LocalTeam);
                    if (((0x8000) > 0) && (iCrosshairIndex > 0 && iCrosshairIndex < 65) && Globals.bTrigger)
                    {
                        if (M8onCross) continue;

                        Thread.Sleep(Globals.iTriggerDelay); // delay before shoot in ms
                        WriteMemory<int>((int)g_pClient + dwForceAttack, 5);
                        Thread.Sleep(80); // delay between shoots in ms
                        WriteMemory<int>((int)g_pClient + dwForceAttack, 4);
                        Thread.Sleep(5); // delay after shoot in ms
                    }
                    #endregion
                    #region BunnyHop
                    #endregion

                }
                #endregion
                #region NoEntityLoopThings
                if (Globals.bNoflash)
                    if (LocalFlash > 1) WriteMemory<int>(Local + m_flFlashMaxAlpha, 0);
                if (Globals.bFov)
                    if (LocalScope == 0)
                        if (LocalFov != 90) WriteMemory<int>(Local + (m_iFOVStart - 4), 90);
                #endregion

                Thread.Sleep(5); // to avoid huge usage CPU
            }

        }
        public static bool IsVisible(int local, int entity)
        {
            int mask = ReadMemory<int>(entity + m_bSpottedByMask);
            int PBASE = ReadMemory<int>(local + 0x64) - 1;
            return (mask & (1 << PBASE)) > 0;
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(1);
        }
        public void CheckMenu()
        {
            // Here we make the main variables equal to what our menu checkboxes say
            while (true)
            {
                Main.S.BunnyhopEnabled = BunnyhopCheck.Checked;
                Main.S.ESP = ESPCheck.Checked;
                Globals.bGlow = checkBox1.Checked;
                Globals.bTrigger = checkBox2.Checked;
                Globals.bRadar = checkBox3.Checked;
                if (int.TryParse(domainUpDown1.Text, out Globals.iTriggerDelay) == true)
                {
                    Globals.iTriggerDelay = int.Parse(domainUpDown1.Text);
                }
                else
                {
                    Globals.iTriggerDelay = 10;
                }

                Thread.Sleep(50); // Greatly reduces cpu usage
            }
        }

        private void DiscordBTN_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discordapp.com/invite/cFmAYvm");
        }

        private void GithubBTN_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Coopyy/ZBase-CSGO");
        }
        #endregion
    }
}
