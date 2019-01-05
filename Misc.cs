// ;

namespace Stealer
{
    public static class Values
    {
        public static float cx = 1252.0f;
        public static float cy = 700.0f - 97.0f;

        public static int gw = 20;
        public static int gh = 12;

        public static float bw = cx / gw;
        public static float bh = cy / gh;
    }

    partial class Form1
    {
        const string rmstring = @"
 Stealer v1.2 by Arime-chan, readme file.
 
 This is an autoclicker, aim for assisting in steal-farming in Matt Roszak's game ""Epic Battle Fantasy 5"".
 Depends on autoskills on equipments, weather effects, and computer speed, each steal (from entering the battle
     to ecscaping to map) takes at least 15 seconds (if steal 2 times), allow you to farm nearly 500 items per hour.
 
 ===== USAGE NOTICE =====
 Despite an assist tool, it still need your ""assist"" to be able to operate properly.
 - Important: Move the tool window so that it don't cover/overlap any click positions. 
 - The tool will occupy your mouse but don't block it, which means you can not use your computer when auto-stealing,
     but you can still move your mouse. However, doing that may compromise the generated click position, causing Matt 
     to drop his whole sword collection down to foes instead of just stealing a Dark Matter.
 - Removing equipments that cast autoskill (Randomly casts X between turns) helps a lot reducing the time taken to
     complete one steal. The lowest I can bring it down to is 10 seconds during test build, but it's unstable so I 
     have to increase some delay. 15 seconds is good enough IMO.
 
 ===== HOW TO USE =====
 1. Set EBF5's resolution to Windowed 700p.
 2. Choose the target in the drop-down box.
 3. Quit the game and reload to clear the Recently Used skills.
 4. Put the two stealing characters in position 1 and 2, and put the ecscape character in position 3.
 5. Perform the stealing and ecscape one time.
     (Do this so the Steal and Normal Attack skill appear in slot 1 of Recently Used skill.)
 6. Click the Steal button.
 7. ALT-TAB to bring the tool window to the front or click on empty space in the tool to stop stealing.
     (Or just simply close the tool.)
 
 ===== WHAT'S NEXT =====
 - Add tooltip on everything so you don't have to read this readme if you want. Almost everything tell what they are
     themselves.
 - (Maybe) implement the feature allow user to setup a custom sequence to farm everywhere. This will require more
     explaination for how to setup one.
";
    }
}
