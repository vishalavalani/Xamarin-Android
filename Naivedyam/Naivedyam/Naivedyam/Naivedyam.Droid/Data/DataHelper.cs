using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Naivedyam.Droid.Models;

namespace Naivedyam.Droid.Data
{
    public class DataHelper
    {
        static DataHelper()
        {
            Init();
        }

        static void Init()
        {
            InitCategories();
            InitMenuItems();
            idliItems = DataHelper.MenuItems.Where(d => d.CategoryID == 1).ToList();
            vadaItems = DataHelper.MenuItems.Where(d => d.CategoryID == 2).ToList();
            upmaItems = DataHelper.MenuItems.Where(d => d.CategoryID == 3).ToList();
            dosaItems = DataHelper.MenuItems.Where(d => d.CategoryID == 4).ToList();
        }

        public static List<Category> CategoryList = new List<Category>();
        public static List<MenuItem> MenuItems = new List<MenuItem>();
        public static List<Cart> CartItems = new List<Cart>();
        public static int OrderNumber;

        public static List<MenuItem> idliItems = new List<MenuItem>();
        public static List<MenuItem> upmaItems = new List<MenuItem>();
        public static List<MenuItem> dosaItems = new List<MenuItem>();
        public static List<MenuItem> vadaItems = new List<MenuItem>();

        static List<Category> InitCategories()
        {
            CategoryList.Add(new Category() { CategoryID = 1, Name = "Idli" });
            CategoryList.Add(new Category() { CategoryID = 2, Name = "Vada" });
            CategoryList.Add(new Category() { CategoryID = 3, Name = "Upma" });
            CategoryList.Add(new Category() { CategoryID = 4, Name = "Dosa" });
            return CategoryList;
        }

        static List<MenuItem> InitMenuItems()
        {
            //Idli
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 1,
                Price = 60,
                Piece = 5,
                Name = "Classic Idlis",
                Description = "Soft steamed rice and lentil batter cakes. Served with Sambar and variety of Chutneys.",
                CategoryID = 1,
                ImageID = Resource.Drawable.classicidli
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 2,
                Price = 70,
                Piece = 5,
                Name = "Rava Idlis",
                Description = "Soft steamed semolina and lentil batter cakes. Served with Sambar and variety of Chutneys.",
                CategoryID = 1,
                ImageID = Resource.Drawable.ravaidli
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 3,
                Price = 80,
                Piece = 5,
                Name = "Vegetable Idlis",
                Description = "Soft steamed rice and lentil batter cakes mixed with vegetables. Served with Sambar and variety of Chutneys.",
                CategoryID = 1,
                ImageID = Resource.Drawable.vegetableidlinew
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 4,
                Price = 65,
                Piece = 5,
                Name = "Dahi Idlis",
                Description = "Rice and lentil batter cakes soaked in curds. Served with Sambar and variety of Chutneys.",
                CategoryID = 1,
                ImageID = Resource.Drawable.dahiidli
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 5,
                Price = 75,
                Piece = 5,
                Name = "Fried Idlis",
                Description = "Deep fried Rice and lentil batter cakes coated with mild masala. Served with Sambar and variety of Chutneys.",
                CategoryID = 1,
                ImageID = Resource.Drawable.friedidli
            });

            //Vadai
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 6,
                Price = 60,
                Piece = 2,
                Name = "Sambhar Vadai",
                Description = "Deep fried lenil batter mixed with onions, mild spices and herbs. Served with Sambar and variety of Chutneys",
                CategoryID = 2,
                ImageID = Resource.Drawable.sambharvada
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 7,
                Price = 70,
                Piece = 2,
                Name = "Thayir Vadai",
                Description = "Vadais soaked in fresh sweet curds. Seasoned with natural aromatic herbs and spices",
                CategoryID = 2,
                ImageID = Resource.Drawable.thayirvada
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 8,
                Price = 80,
                Piece = 2,
                Name = "Dal Vadai",
                Description = "Deep fried chikpea lentil batter mixed with South Indian spices, finely chopped vegetables and aromatic herbs",
                CategoryID = 2,
                ImageID = Resource.Drawable.dalvada
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 9,
                Price = 75,
                Piece = 2,
                Name = "Rasam Vadai",
                Description = "Vadais immersed ina bowl of tangy South Indian lentil Soup",
                CategoryID = 2,
                ImageID = Resource.Drawable.rasamvada
            });

            //Upma
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 10,
                Price = 50,
                Piece = 1,
                Name = "Rava Upma",
                Description = "Thick porridge cake prepared with semolina, mild aromatic herbs and south Indian spices",
                CategoryID = 3,
                ImageID = Resource.Drawable.ravaupma
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 11,
                Price = 80,
                Piece = 1,
                Name = "Vegetable Upma",
                Description = "Thick porridge cake prepared with semolina, vegetables, mild aromatic herbs and south indian spices",
                CategoryID = 3
                ,
                ImageID = Resource.Drawable.vegetableupma
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 12,
                Name = "Idiappam",
                Piece = 4,
                Price = 90,
                Description = "Soft and find rice noodles serveed with sweet coconut milk",
                CategoryID = 3,
                ImageID = Resource.Drawable.idiappam
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 13,
                Price = 110,
                Piece = 2,
                Name = "Chow Chow Bhath",
                Description = "Combination of Rava Upma dna Kesri Bhath. Kesri Bhath is the sweet version of Rava Upma prepared with pineapples",
                CategoryID = 3,
                ImageID = Resource.Drawable.chowchowbhath
            });

            //Rice Dosas
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 14,
                Price = 110,
                Piece = 1,
                Name = "Plain Dosa",
                Description = "Simple plain dosa with sambar and chutneys",
                CategoryID = 4,
                ImageID = Resource.Drawable.plaindosa
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 15,
                Piece = 1,
                Price = 130,
                Name = "Udupi Masala Dosa",
                Description = "Cripsy rice pancake filled with mildly spiced mashed potatoes",
                CategoryID = 4,
                ImageID = Resource.Drawable.bennemasala
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 16,
                Price = 140,
                Piece = 1,
                Name = "Mahavir Masala Dosa",
                Description = "Prepared without onion and garlic. Cripsy rice pancake served with mildly spiced mashed potatoes",
                CategoryID = 4,
                ImageID = Resource.Drawable.mahavirdosa
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 17,
                Piece = 1,
                Price = 170,
                Name = "Paneer Masala Dosa",
                Description = "Crispy rice pancake stuffed with mildly spiced cottage cheese mix",
                CategoryID = 4,
                ImageID = Resource.Drawable.paneermasala
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 18,
                Price = 180,
                Piece = 1,
                Name = "Mysore Plain Masala Dosa",
                Description = "Crispy rice pancake coated with our special chilly garlic paste",
                CategoryID = 4,
                ImageID = Resource.Drawable.mysoremasala
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 19,
                Price = 190,
                Piece = 1,
                Name = "Mysore Masala Dosa",
                Description = "Crispy rice pancake coated with our special chilly garlic paste. Filled with mildly spiced mashed potatoes",
                CategoryID = 4,
                ImageID = Resource.Drawable.mysoremasala
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 20,
                Price = 160,
                Piece = 1,
                Name = "Tangam Paper Dosa",
                Description = "Extra large, paper thin, crispy rice pancake",
                CategoryID = 4,
                ImageID = Resource.Drawable.tangamplain
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 21,
                Price = 170,
                Piece = 1,
                Name = "Tangam Paper Masala Dosa",
                Description = "Extra large, paper thin, crispy rice pancake filled with mildly spiced mashed potatoes",
                CategoryID = 4,
                ImageID = Resource.Drawable.tangammasala
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 22,
                Piece = 1,
                Price = 210,
                Name = "Banne Plain Dosa",
                Description = "Crispy rice pancake prepared in butter",
                CategoryID = 4,
                ImageID = Resource.Drawable.benneplain
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 23,
                Piece = 1,
                Price = 220,
                Name = "Banne Masala Dosa",
                Description = "Crispy rice pancake prepared in butter filled with mildly spiced mashed potatoes",
                CategoryID = 4,
                ImageID = Resource.Drawable.bennemasala
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 24,
                Price = 185,
                Piece = 1,
                Name = "Erulli Plain Dosa",
                Description = "Crispy golden semolina pancake coated with finely chopped red onions",
                CategoryID = 4,
                ImageID = Resource.Drawable.erulliplain
            });
            MenuItems.Add(new MenuItem()
            {
                MenuItemID = 25,
                Piece = 1,
                Price = 200,
                Name = "Erulli Masala Dosa",
                Description = "Crispy golden semolina pancake coated with finely chopped red onions filled with mildly spiced mashed potatoes",
                CategoryID = 4,
                ImageID = Resource.Drawable.erullimasala
            });


            return MenuItems;
        }
    }




}