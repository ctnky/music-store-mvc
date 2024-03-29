﻿using MusicStore.BLL.Abstract;
using MusicStore.DAL.Abstract;
using MusicStore.Model;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.BLL.Concrete
{
    public class AlbumService : IAlbumService
    {
        IAlbumDAL _albumDAL;

        public AlbumService(IAlbumDAL album)
        {
            _albumDAL = album;
        }

        public void Delete(Album entity)
        {
            _albumDAL.Remove(entity);
        }

        public void DeleteById(int entityID)
        {
            Album album = _albumDAL.Get(a => a.ID == entityID);
            Delete(album);
        }

        public Album Get(int entityID)
        {
            return _albumDAL.Get(a => a.ID == entityID);
        }


        public ICollection<Album> GetAll()
        {
            return _albumDAL.GetAll();
        }

        public void Insert(Album entity)
        {
            _albumDAL.Add(entity);
        }

        public void Update(Album entity)
        {
            _albumDAL.Update(entity);
        }

        public List<Album> GetDiscountedAlbums()
        {
            return _albumDAL.GetAll(a => a.Discounted).ToList();
        }

        public List<Album> GetLastFiveAlbums()
        {
            return _albumDAL.GetAll().OrderByDescending(a => a.CreatedDate).Take(5).ToList();
        }

        public List<Album> GetAlbumOfGenre(int genreID)
        {
            return _albumDAL.GetAll(a => a.GenreID == genreID).ToList();
        }
    }
}
