using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TotoToolDB.Models;

namespace TotoToolDB.Classes.Core
{
    public class CategoriaCore
    {
        TotoToolDbContext dbContext;
        public CategoriaCore(TotoToolDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Categoria> GetAll()
        {
            try
            {
                /*List<Categoria> categoria = (from s in dbContext.Categoria
                                             where s.Nombre == "CATEGORIA1"
                                             select s).ToList();*/
                return dbContext.Categoria.ToList();
            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Create(Categoria categoria)
        {
            try
            {
                bool validCategoria = Validate(categoria);

                if (validCategoria)
                {
                    dbContext.Add(categoria);
                    dbContext.SaveChanges();
                }

            } catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Validate(Categoria categoria)
        {
            try
            {
                if (string.IsNullOrEmpty(categoria.Nombre))
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Categoria categoria, int id)
        {
            try
            {
                bool validCategoria = Validate(categoria);

                if (validCategoria)
                {
                    bool existCategoria = dbContext.Categoria.Any(categoria => categoria.Id == id);
                    if (existCategoria)
                    {
                        categoria.Id = id;
                        dbContext.Update(categoria);
                        dbContext.SaveChanges();
                    }
                }

            } catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(int id)
        {
            try
            {
                //bool existCategoria = dbContext.Categoria.Any(categoria => categoria.Id == id);
                Categoria categoria = dbContext.Categoria.FirstOrDefault(x => x.Id == id);
                if (categoria != null)
                {
                    categoria.Id = id;
                    dbContext.Update(categoria);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
