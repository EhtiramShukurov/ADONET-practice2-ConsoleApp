using SpotifyProject.Abstractions;
using SpotifyProject.Contexts;
using SpotifyProject.Models;
using SpotifyProject.Services;
using System.Collections;
using System.Data.SqlClient;

namespace SpotifyProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        public static void Menu()
        {
            Context context = new Context();
            Console.WriteLine("Choose table to work on: \n\n1.Musics\n2.Artists\n3.Categories\n4.Roles\n5.Users\n6.Playlists\n7.Playlist Musics\n8.Full Musics\n");
            int option;
            int option2;
            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Wrong input,enter again");
            }
            Console.WriteLine("Choose Crud operation:\n1.Get All\n2.Get by Id\n3.Create\n4.Update\n5.Delete\n0.Quit");
            while (!int.TryParse(Console.ReadLine(), out option2))
            {
                Console.WriteLine("Wrong input,enter again");
            }
            switch (option2)
            {
                case 1:
                    Console.Clear();
                    GetAllMenu(context, option);
                    break;
                case 2:
                    Console.Clear();

                    GetByIdMenu(context, option);
                    break;
                case 3:
                    Console.Clear();

                    CreateMenu(context, option);
                    break;
                case 4:
                    Console.Clear();

                    UpdateMenu(context, option);
                    break;
                case 5:
                    Console.Clear();

                    DeleteByIdMenu(context, option);
                    break;
                case 0:
                    Console.WriteLine("Program closed");
                    return;
                default:
                    break;
            }
        }

        public static void GetAllMenu(Context context,int a)
        {
            while (true)
            {
                switch (a)
                {
                    case 1:
                        foreach (Music item in context.Musics.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 2:
                        foreach (Artist item in context.Artists.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 3:
                        foreach (Category item in context.Categories.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 4:
                        foreach (Role item in context.Roles.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 5:
                        foreach (User item in context.Users.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 6:
                        foreach (Playlist item in context.Playlist.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 7:
                        foreach (PlaylistMusic item in context.PlaylistMusics.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 8:
                        foreach (FullMusic item in context.FullMusics.GetAll())
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Program Closed");
                        return;
                    default:
                        Console.WriteLine("Incorrect case,enter again");
                        while(!int.TryParse(Console.ReadLine(), out a))
                        {
                            Console.WriteLine("Wrong input,enter again");
                        }
                        break;

                }
                Console.WriteLine("\n\nPress anything to go back to menu or 0 to quit");
                while (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Wrong input,enter again");
                }
                    Console.Clear();
                    Menu();
                    return;
            }

        }
        public static void GetByIdMenu(Context context,int a)
        {
            int id;
            Console.WriteLine("Enter id:");
            while (!int.TryParse(Console.ReadLine(),out id))
            {
                Console.WriteLine("Wrong input,try again");
            }
            while (true)
            {
                try
                {
                    switch (a)
                    {
                        case 1:
                            Console.WriteLine(context.Musics.GetById(id));
                            break;
                        case 2:
                            Console.WriteLine(context.Artists.GetById(id));

                            break;
                        case 3:
                            Console.WriteLine(context.Categories.GetById(id));

                            break;
                        case 4:
                            Console.WriteLine(context.Roles.GetById(id));
                            return;
                        case 5:
                            Console.WriteLine(context.Users.GetById(id));
                            break;
                        case 6:
                            Console.WriteLine(context.Playlist.GetById(id));
                            break;
                        case 7:
                            Console.WriteLine(context.PlaylistMusics.GetById(id));
                            break;
                        case 8:
                            Console.WriteLine(context.FullMusics.GetById(id));
                            break;
                        case 0:
                            Console.WriteLine("Program Closed");
                            return;
                        default:
                            Console.WriteLine("Incorrect case,enter again");
                            while (int.TryParse(Console.ReadLine(), out a))
                            {
                                Console.WriteLine("Wrong input,enter again");
                            }
                            continue;
                    }
                    Console.WriteLine("\n\nPress anything to go back to menu or 0 to quit");
                    while (!int.TryParse(Console.ReadLine(), out a))
                    {
                        Console.WriteLine("Wrong input,enter again");
                    }
                    Console.Clear();
                    Menu();
                    return;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

                
        }

        public static void DeleteByIdMenu(Context context, int a)
        {
            int id;
            Console.WriteLine("Enter id for deleting");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong input,try again");
            }
            while (true)
            {
                switch (a)
                {
                    case 1:
                        context.Musics.DeleteById(id);
                        break;
                    case 2:
                        context.Artists.DeleteById(id);

                        break;
                    case 3:
                        context.Categories.DeleteById(id);

                        break;
                    case 4:
                        context.Roles.DeleteById(id);
                        break;
                    case 5:
                        context.Users.DeleteById(id);
                        break;
                    case 6:
                        context.Playlist.DeleteById(id);
                        break;
                    case 7:
                        context.PlaylistMusics.DeleteById(id);
                        break;
                    case 8:
                        context.FullMusics.DeleteById(id);
                        break;
                    case 0:
                        Console.WriteLine("Program Closed");
                        return;
                    default:
                        Console.WriteLine("Incorrect case,enter again");
                        while (int.TryParse(Console.ReadLine(), out a))
                        {
                            Console.WriteLine("Wrong input,enter again");
                        }
                        continue;
                }
                Console.WriteLine("\n\nPress anything to go back to menu or 0 to quit");
                while (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Wrong input,enter again");
                }
                Console.Clear();
                Menu();
                return;
            }
        }

        public static void UpdateMenu(Context context, int a)
        {
            string name = "";
            int id;
            int id2;

            Console.WriteLine("Enter id");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Wrong input,try again");
            }
            while (true)
            {
                switch (a)
                {
                    case 1:
                        Music music = context.Musics.GetById(id);
                        Console.WriteLine("Enter name to update");
                        name = Console.ReadLine();
                        while (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Wrong input,enter again");
                            name = Console.ReadLine();
                        }
                        music.Name = name;
                        context.Musics.Update(music);
                        break;
                    case 2:
                        Artist artist = context.Artists.GetById(id);
                        Console.WriteLine("Enter name to update");
                        name = Console.ReadLine();
                        while (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Wrong input,enter again");
                            name = Console.ReadLine();
                        }
                        artist.Name = name;
                        context.Artists.Update(artist);

                        break;
                    case 3:
                        Category category = context.Categories.GetById(id);
                        Console.WriteLine("Enter name to update");
                        name = Console.ReadLine();
                        while (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Wrong input,enter again");
                            name = Console.ReadLine();
                        }
                        category.Name = name;
                        context.Categories.Update(category);

                        break;
                    case 4:
                        Role role = context.Roles.GetById(id);
                        Console.WriteLine("Enter name to update");
                        name = Console.ReadLine();
                        while (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Wrong input,enter again");
                            name = Console.ReadLine();
                        }
                        role.Type = name;
                        context.Roles.Update(role);
                        break;
                    case 5:
                        User user = context.Users.GetById(id);
                        Console.WriteLine("Enter name to update");
                        name = Console.ReadLine();
                        while (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Wrong input,enter again");
                            name = Console.ReadLine();
                        }
                        user.Name = name;
                        context.Users.Update(user);
                        break;
                    case 6:
                        Playlist playlist = context.Playlist.GetById(id);
                        Console.WriteLine("Enter name to update");
                        name = Console.ReadLine();
                        while (string.IsNullOrEmpty(name))
                        {
                            Console.WriteLine("Wrong input,enter again");
                            name = Console.ReadLine();
                        }
                        playlist.Name = name;
                        context.Playlist.Update(playlist);
                        break;
                    case 7:
                        Console.WriteLine("Enter music id to change");
                        while (int.TryParse(Console.ReadLine(), out id2))
                        {
                            Console.WriteLine("Wrong input,enter again");
                        }

                        PlaylistMusic pm = context.PlaylistMusics.GetById(id);
                        pm.MusicId = id2;
                        context.PlaylistMusics.Update(pm);
                        break;
                    case 0:
                        Console.WriteLine("Program Closed");
                        return;
                    case 8:
                        Console.WriteLine("Enter music id to change");
                        while (int.TryParse(Console.ReadLine(), out id2))
                        {
                            Console.WriteLine("Wrong input,enter again");
                        }

                        FullMusic fm = context.FullMusics.GetById(id);
                        fm.MusicId = id2;
                        context.FullMusics.Update(fm);
                        break;
                    default:
                        Console.WriteLine("Incorrect case,enter again");
                        while (int.TryParse(Console.ReadLine(), out a))
                        {
                            Console.WriteLine("Wrong input,enter again");
                        }
                        continue;
                }
                Console.WriteLine("\n\nPress anything to go back to menu or 0 to quit");
                while (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Wrong input,enter again");
                }
                Console.Clear();
                Menu();
                return;
            }
        }
        public static void CreateMenu(Context context, int a)
        {
            while (true)
            {
                switch (a)
                {
                    case 1:
                        context.Musics.Add(context.Musics.Create());
                        break;
                    case 2:
                        context.Artists.Add(context.Artists.Create());
                        break;
                    case 3:
                        context.Categories.Add(context.Categories.Create());

                        break;
                    case 4:
                        context.Roles.Add(context.Roles.Create());

                        break;
                    case 5:
                        context.Users.Add(context.Users.Create());

                        break;
                    case 6:
                        context.Playlist.Add(context.Playlist.Create());
                        break;
                    case 7:
                        context.PlaylistMusics.Add(context.PlaylistMusics.Create());

                        break;
                    case 8:
                        context.FullMusics.Add(context.FullMusics.Create());
                        break;
                    case 0:
                        Console.WriteLine("Program Closed");
                        return;
                    default:
                        Console.WriteLine("Incorrect case,enter again");
                        while (int.TryParse(Console.ReadLine(), out a))
                        {
                            Console.WriteLine("Wrong input,enter again");
                        }
                        continue;

                }
                Console.WriteLine("\n\nPress anything to go back to menu or 0 to quit");
                while (!int.TryParse(Console.ReadLine(), out a))
                {
                    Console.WriteLine("Wrong input,enter again");
                }
                Console.Clear();
                Menu();
                return;
            }
        }



    }
}