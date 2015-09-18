using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace win2d_procedural_rooms
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        int nMaxRooms = 50;
        List<Room> Rooms = new List<Room>();

        enum GAMESTATE
        {
            ADDING_ROOMS,
            SEPARATING_ROOMS,
            DONE
        }

        GAMESTATE State = GAMESTATE.ADDING_ROOMS;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void gridMain_PointerReleased(object sender, PointerRoutedEventArgs e)
        {

        }

        private void gridMain_PointerMoved(object sender, PointerRoutedEventArgs e)
        {

        }

        private void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            foreach(Room room in Rooms)
            {
                room.Draw(args);
            }
        }

        private void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        {
            switch(State)
            {
                case GAMESTATE.ADDING_ROOMS:
                    if (Rooms.Count < nMaxRooms)
                    {
                        Rooms.Add(Room.CreateRandomRoom());
                    }
                    else
                    {
                        State = GAMESTATE.SEPARATING_ROOMS;
                    }
                    break;
                case GAMESTATE.SEPARATING_ROOMS:
                    break;
                case GAMESTATE.DONE:
                    break;
            }
        }

        private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args)
        {
            args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        }

        async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        {
            Statics.CenterScreenX = (int)sender.Size.Width / 2;
            Statics.CenterScreenY = (int)sender.Size.Height / 2;
        }


        //#region Initialization
        //private void canvasMain_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args)
        //{
        //    args.TrackAsyncAction(CreateResourcesAsync(sender).AsAsyncAction());
        //}
        //async Task CreateResourcesAsync(CanvasAnimatedControl sender)
        //{
        //    // c.TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 200);
        //    // c.Paused = true;

        //    Statics.CrownImage = await CanvasBitmap.LoadAsync(sender, "game\\crown.png");
        //    Statics.LeftColumnWidth = (int)sender.Size.Width - Statics.RightColumnWidth - Statics.RightColumnPadding * 2 - Statics.LeftColumnPadding * 2;
        //    Statics.CanvasHeight = (int)sender.Size.Height;

        //    Statics.ColumnDividerTop = new Vector2(Statics.LeftColumnWidth + Statics.LeftColumnPadding * 2, 0);
        //    Statics.ColumnDividerBottom = new Vector2(Statics.LeftColumnWidth + Statics.LeftColumnPadding * 2, (float)sender.Size.Height);

        //    rlbProminent = new RichListBoxProminent(sender.Device,
        //                                   new Vector2(Statics.LeftColumnWidth + Statics.LeftColumnPadding * 2 + Statics.RightColumnPadding, Statics.RightColumnPadding),
        //                                   Statics.RightColumnWidth,
        //                                   "Census of Recent Contentions", Statics.FontLarge,
        //                                   15, Statics.FontSmall,
        //                                   Statics.FontLarge);

        //    rlbLeaderboard = new RichListBoxLeaderboard(sender.Device,
        //                                                new Vector2(rlbProminent.Position.X, rlbProminent.Position.Y + rlbProminent.Height + Statics.RightColumnPadding),
        //                                                rlbProminent.Width,
        //                                                (int)sender.Size.Height - rlbProminent.Height - Statics.RightColumnPadding * 3,
        //                                                "Champions of the Realm",
        //                                                Statics.FontLarge,
        //                                                Statics.FontSmall,
        //                                                Statics.FontMedium);

        //    // initialize leaderboard listbox
        //    Leaderboard.AttachedListbox = rlbLeaderboard;
        //    Leaderboard.InitializeListboxInfo();

        //    // resets map, listbox, debug frame count
        //    Reset(sender);
        //}
        //private void Reset(ICanvasAnimatedControl sender)
        //{
        //    Statics.FrameCount = 0;
        //    rlbProminent.Clear();
        //    map = new Map(Statics.MapPosition);
        //}
        //#endregion

        //#region Draw
        //private void canvasMain_Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        //{
        //    map.Draw(args);
        //    rlbProminent.Draw(args);
        //    rlbLeaderboard.Draw(args);

        //    // args.DrawingSession.DrawLine(Statics.ColumnDividerTop, Statics.ColumnDividerBottom, Colors.White);
        //    // Leaderboard.Draw(args);

        //    //DrawDebug(args);
        //}
        //private void DrawDebug(CanvasAnimatedDrawEventArgs args)
        //{
        //    args.DrawingSession.DrawText("Mouse: " + Statics.MouseX.ToString() + ", " + Statics.MouseY.ToString(), new Vector2(1200, 800), Colors.White);
        //    args.DrawingSession.DrawText("Max String: " + Statics.MaxStringWidth.ToString(), new Vector2(1200, 820), Colors.White);
        //}
        //#endregion

        //#region Update
        //private void canvasMain_Update(ICanvasAnimatedControl sender, CanvasAnimatedUpdateEventArgs args)
        //{
        //    if (map.Finished)
        //    {
        //        Reset(sender);
        //    }
        //    else
        //    {
        //        Statics.FrameCount++;
        //        map.Update(rlbProminent, args);
        //    }
        //}
        //#endregion

        //#region Input
        //private void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
        //{
        //    canvasMain.Paused = !canvasMain.Paused;
        //}
        //private void gridMain_PointerMoved(object sender, PointerRoutedEventArgs e)
        //{
        //    Statics.MouseX = (int)e.GetCurrentPoint(gridMain).Position.X;
        //    Statics.MouseY = (int)e.GetCurrentPoint(gridMain).Position.Y;
        //}
        //#endregion
    }
}
