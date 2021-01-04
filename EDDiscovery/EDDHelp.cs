﻿/*
 * Copyright © 2018 EDDiscovery development team
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this
 * file except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software distributed under
 * the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
 * ANY KIND, either express or implied. See the License for the specific language
 * governing permissions and limitations under the License.
 * 
 * EDDiscovery is not affiliated with Frontier Developments plc.
 */

using BaseUtils.JSON;
using EDDiscovery.UserControls;
using ExtendedControls;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EDDiscovery
{
    public static class EDDHelp 
    {
        // NOTE! keep synced with JSON on EDDiscovery data as this gets downloaded by EDDControllermain.cs::DownloadHelp once per day

        static private JToken defaulthelp = new JObject()
        {
            ["Version"] = "1.2.0.0",
            ["Panels"] = new JArray()
            {
                new JObject() { ["panel"] = "Log", ["wiki"] = "/Using-the-EDDiscovery-Log-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "StarDistance", ["wiki"] = "/Using-the-Nearest-Stars-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Materials", ["wiki"] = "/Using-the-Materials-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Commodities", ["wiki"] = "/Using-the-Commodities-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Ledger", ["wiki"] = "/Using-the-Ledger-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Journal", ["wiki"] = "/Using-the-Journal-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "TravelGrid", ["wiki"] = "/Using-the-History-Grid-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "ScreenShot", ["wiki"] = "/Using-the-Screenshot-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Statistics", ["wiki"] = "/Using-the-Statistics-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Scan", ["wiki"] = "/Using-the-Scan-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Modules", ["wiki"] = "/Using-the-Ships-Load-Out-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Exploration", ["wiki"] = "/Using-the-Exploration-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Synthesis", ["wiki"] = "/Using-the-Synthesis-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Missions", ["wiki"] = "/Using-the-Missions-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Engineering", ["wiki"] = "/Using-the-Engineering-panel", ["video"] = "" },
                new JObject() { ["panel"] = "MarketData", ["wiki"] = "/Using-the-Market-Data-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "SystemInformation", ["wiki"] = "/Using-the-System-Information-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Spanel", ["wiki"] = "/Using-the-SPanel", ["video"] = "" },
                new JObject() { ["panel"] = "Trippanel", ["wiki"] = "/Using-the-Trip-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "NotePanel", ["wiki"] = "/Using-the-Note-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "RouteTracker", ["wiki"] = "/Using-the-Route-Tracker-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Grid", ["wiki"] = "/Using-the-Grid", ["video"] = "https://youtu.be/fSnxTDL90B4?t=346" },
                new JObject() { ["panel"] = "StarList", ["wiki"] = "/Using-the-Star-List-Grid", ["video"] = "" },
                new JObject() { ["panel"] = "EstimatedValues", ["wiki"] = "/Using-the-Estimated-Exploration-Values-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Search", ["wiki"] = "/Using-the-Search-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "ShoppingList", ["wiki"] = "/Using-the-Shopping-List-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Route", ["wiki"] = "/Using-the-Route-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Expedition", ["wiki"] = "/Using-the-Expeditions-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Trilateration", ["wiki"] = "/Using-the-Trilateration-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Settings", ["wiki"] = "/Using-the-Settings-Panel", ["video"] = "/watch?v=v5g03mYdYAw" },
                new JObject() { ["panel"] = "ScanGrid", ["wiki"] = "/Using-the-Scan-Grid", ["video"] = "" },
                new JObject() { ["panel"] = "Compass", ["wiki"] = "/Using-the-Compass-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "LocalMap", ["wiki"] = "/Using-the-Map-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Plot", ["wiki"] = "/Using-the-Plot-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "PanelSelector", ["wiki"] = "/Using-Panels", ["video"] = "" },
                new JObject() { ["panel"] = "BookmarkManager", ["wiki"] = "/Using-the-Bookmarks-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "CombatPanel", ["wiki"] = "/Using-the-combat-panel", ["video"] = "" },
                new JObject() { ["panel"] = "ShipYardPanel", ["wiki"] = "/Using-the-Shipyard-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "OutfittingPanel", ["wiki"] = "/Using-the-Outfitting-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "SplitterControl", ["wiki"] = "/Using-the-Splitter", ["video"] = "https://youtu.be/fSnxTDL90B4?t=209" },
                new JObject() { ["panel"] = "MissionOverlay", ["wiki"] = "/Using-the-Mission-Overlay-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "CaptainsLog", ["wiki"] = "/Using-the-Captains-Log-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Surveyor", ["wiki"] = "/Using-the-Surveyor-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "EDSM", ["wiki"] = "/Using-the-WebView-Panels", ["video"] = "" },
                new JObject() { ["panel"] = "Inara", ["wiki"] = "/Using-the-WebView-Panels", ["video"] = "" },
                new JObject() { ["panel"] = "Spansh", ["wiki"] = "/Using-the-WebView-Panels", ["video"] = "" },
                new JObject() { ["panel"] = "EDDB", ["wiki"] = "/Using-the-WebView-Panels", ["video"] = "" },
                new JObject() { ["panel"] = "MaterialTrader", ["wiki"] = "/Using-the-Material-Trader-Panel", ["video"] = "" },
                new JObject() { ["panel"] = "Map2D", ["wiki"] = "/Using-the-2D-Map", ["video"] = "" },
                new JObject() { ["panel"] = "MiningOverlay", ["wiki"] = "/Using-the-mining-panel", ["video"] = "" },
                new JObject() { ["panel"] = "HistoryTab", ["wiki"] = "/Using-the-History-Tab", ["video"] = "" },
                new JObject() { ["panel"] = "Factions", ["wiki"] = "/Using-the-Factions-Panel", ["video"] = "" },
            }
        };

        public static void Help(Form parent, Point p, UserControlCommonBase uccb)
        {
            var pid = PanelInformation.GetPanelIDByControltype(uccb.GetType());
            Help(parent, p, pid.ToString());
        }

        public static void HistoryTab(Form parent, Point p)
        {
            Help(parent,p,"HistoryTab");
        }

        // do videos
        // use file in folder if present, download folder..

        public static void Help(Form parent, Point pos, string name)
        {
            JToken helptouse = defaulthelp;

            string helpfile = Path.Combine(EDDOptions.Instance.HelpDirectory(), "help.json");
            if (File.Exists(helpfile))
            {
                string t = BaseUtils.FileHelpers.TryReadAllTextFromFile(helpfile);
                JToken filejson = t != null ? JToken.Parse(t) : null;
                if (filejson != null)
                {
                    Version intv = new Version(helptouse["Version"].Str("0.0.0.0"));
                    Version filev = new Version(filejson["Version"].Str("0.0.0.0"));

                    if ( filev >= intv )
                        helptouse = filejson;
                }
            }

            //System.IO.File.WriteAllText(@"c:\code\help.json",helptouse.ToString(true));
            //System.Diagnostics.Debug.WriteLine("Help on " + name);

            string wiki = Properties.Resources.URLProjectWiki;      // default..
            string video = Properties.Resources.URLProjectVideos;

            JArray panels = helptouse["Panels"].Array();            // may be null if there is trouble

            JToken obj = panels?.Where(x => x.Object()["panel"].ValueEquals(name)).Select(x => x).FirstOrDefault() ?? null;     // allow for panels to be null
            if (obj != null)
            {
                wiki = obj["wiki"].StrNull();
                video = obj["video"].StrNull();

                if (wiki != null && wiki.StartsWith("/"))
                    wiki = Properties.Resources.URLProjectWiki + wiki;

                if (video != null && video.StartsWith("/"))
                    video = Properties.Resources.URLProjectVideosRoot + video;

                //System.Diagnostics.Debug.WriteLine("For {0} {1} {2}", name, wiki, video);
            }

            if (wiki.HasChars() && video.HasChars())
            {
                ConfigurableForm cfg = new ExtendedControls.ConfigurableForm();
                cfg.AllowSpaceForScrollBar = false;
                cfg.RightMargin = cfg.BottomMargin = 0;
                cfg.ForceNoBorder = true;
                cfg.AllowSpaceForCloseButton = true;
                cfg.BorderMargin = 0;

                ExtButton wikibutton = new ExtButton();
                wikibutton.Image = global::EDDiscovery.Icons.Controls.Help_Wiki;
                cfg.Add(new ConfigurableForm.Entry(wikibutton, "Wiki", null, new Point(0, 0), new Size(24, 24), null));
                ExtButton videobutton = new ExtButton();
                videobutton.Image = global::EDDiscovery.Icons.Controls.Help_Video;
                cfg.Add(new ConfigurableForm.Entry(videobutton, "Video", null, new Point(26, 0), new Size(24, 24), null));

                cfg.Trigger += (string logicalname, string ctrlname, object callertag) =>
                {
                    if (ctrlname == "Close")
                        cfg.ReturnResult(DialogResult.Cancel);
                    else if (ctrlname == "Wiki")
                        cfg.ReturnResult(DialogResult.OK);
                    else if (ctrlname == "Video")
                        cfg.ReturnResult(DialogResult.Yes);
                };

                DialogResult res = cfg.ShowDialog(parent, pos, parent.Icon, "", closeicon: true);
                if (res == DialogResult.OK)
                    System.Diagnostics.Process.Start(wiki);
                else if (res == DialogResult.Yes)
                    System.Diagnostics.Process.Start(video);
            }
            else if (wiki.HasChars())
                System.Diagnostics.Process.Start(wiki);
            else if (video.HasChars())
                System.Diagnostics.Process.Start(video);
            else
                MessageBox.Show("No help for " + name);

        }

      }
}
