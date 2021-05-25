using System;

namespace proiect_ii.Database.Game
{
    public class Game
    {
        public int id { get; set; }
        public string name { get; set; }

        public string publisher { get; set; }

        public string developer { get; set; }

        public string description { get; set; }

        public string category1 { get; set; }

        public string category2 { get; set; }

        public string category3 { get; set; }

        public string main_img_link { get; set; }

        public string showoff_img_link_1 { get; set; }

        public string showoff_img_link_2 { get; set; }

        public string showoff_img_link_3 { get; set; }

        public string showoff_img_link_4 { get; set; }

        public string showoff_img_link_5 { get; set; }

        public string showoff_video_link_1 { get; set; }

        public string showoff_video_link_2 { get; set; }

        public double price { get; set; }
    }
}
