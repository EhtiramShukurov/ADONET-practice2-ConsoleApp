using SpotifyProject.Abstractions;
using SpotifyProject.Models;
using SpotifyProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyProject.Contexts
{
    internal class Context
    {
        IService<Artist> _artists;
        IService<Category> _categories;
        IService<Music> _musics;
        IService<FullMusic> _fullMusics;
        IService<Playlist> _playlists;
        IService<PlaylistMusic> _playlistMusics;
        IService<Role> _roles;
        IService<User> _users;
        public IService<Artist> Artists
        {
            get
            {
                if (_artists == null)
                {
                    _artists = new ArtistService();
                }
                return _artists;
            }
        }
        public IService<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new CategoryService();
                }
                return _categories;
            }
        }
        public IService<Music> Musics
        {
            get
            {
                if (_musics == null)
                {
                    _musics = new MusicService();
                }
                return _musics;
            }
        }
        public IService<FullMusic> FullMusics
        {
            get
            {
                if (_fullMusics == null)
                {
                    _fullMusics = new FullMusicService();
                }
                return _fullMusics;
            }
        }
        public IService<Playlist> Playlist
        {
            get
            {
                if (_playlists == null)
                {
                    _playlists = new PlaylistService();
                }
                return _playlists;
            }
        }
        public IService<PlaylistMusic> PlaylistMusics
        {
            get
            {
                if (_playlistMusics == null)
                {
                    _playlistMusics = new PlaylistMusicService();
                }
                return _playlistMusics;
            }
        }
        public IService<Role> Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new RoleService();
                }
                return _roles;
            }
        }
        public IService<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserService();
                }
                return _users;
            }
        }
    }
}
