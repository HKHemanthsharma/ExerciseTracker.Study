using ExerciseTracker.Study.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTracker.Study.Repositories
{
    public class RepositoryClass<T> : IRepository<T> where T:class
    {
        private readonly ContextClass Context;
        private readonly DbSet<T> DbSet;
        public RepositoryClass(ContextClass _context)
        {
            Context = _context;
            DbSet = _context.Set<T>();
        }
        public async Task<ResponseDto<T>> Create(T Entity)
        {
            try
            {
                var EntityResponse = await DbSet.AddAsync(Entity);
                await Context.SaveChangesAsync();
                return new ResponseDto<T>
                {
                    IsSuccess = true,
                    ResponseMethod = "Post",
                    Message = "Successfully Created The Entity",
                    Data = new List<T> { EntityResponse.Entity }
                };
            }
            catch(Exception e)
            {
                return new ResponseDto<T>
                {
                    IsSuccess = false,
                    ResponseMethod = "Post",
                    Message = "Error Occured: "+e.Message,
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<T>> Delete(T Entity)
        {
            try
            {
                if (await DbSet.FindAsync(Entity) != null)
                {
                    DbSet.Remove(Entity);
                    Context.SaveChanges();
                    return new ResponseDto<T>
                    {
                        IsSuccess = true,
                        ResponseMethod = "Delete",
                        Message = "Successfully Deleted The Entities",
                        Data = null
                    };
                }
                else
                {
                    return new ResponseDto<T>
                    {
                        IsSuccess = false,
                        ResponseMethod = "Delete",
                        Message = "No Entity Found to Delete",
                        Data = null
                    };
                }
            }
            catch (Exception e)
            {
                return new ResponseDto<T>
                {
                    IsSuccess = false,
                    ResponseMethod = "Delete",
                    Message = "Error Occured: " + e.Message,
                    Data = null
                };
            }

        }

        public async Task<ResponseDto<T>> GetAll()
        {
            try
            {
                var DataList = await DbSet.ToListAsync();
                return new ResponseDto<T>
                {
                    IsSuccess = true,
                    ResponseMethod = "Get",
                    Message = "Successfully Fetched All The Entities",
                    Data = DataList
                };
            }
            catch (Exception e)
            {
                return new ResponseDto<T>
                {
                    IsSuccess = false,
                    ResponseMethod = "Get",
                    Message = "Error Occured: " + e.Message,
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<T>> GetById(int Id)
        {
            try
            {
                var DataEntity = await DbSet.FindAsync(Id);
                return new ResponseDto<T>
                {
                    IsSuccess = true,
                    ResponseMethod = "Get",
                    Message = "Successfully Fetched The Entity With Id",
                    Data = new List<T> { DataEntity }
                };
            }
            catch (Exception e)
            {
                return new ResponseDto<T>
                {
                    IsSuccess = false,
                    ResponseMethod = "Get",
                    Message = "Error Occured: " + e.Message,
                    Data = null
                };
            }
        }

        public async Task<ResponseDto<T>> Update(T Entity)
        {
            try
            {
                if (await DbSet.FindAsync(Entity) != null)
                {
                    DbSet.Update(Entity);
                    Context.SaveChanges();
                    return new ResponseDto<T>
                    {
                        IsSuccess = true,
                        ResponseMethod = "Update",
                        Message = "Successfully Updated The Entities",
                        Data = null
                    };
                }
                else
                {
                    return new ResponseDto<T>
                    {
                        IsSuccess = false,
                        ResponseMethod = "Update",
                        Message = "No Entity Found to Update",
                        Data = null
                    };
                }
            }
            catch (Exception e)
            {
                return new ResponseDto<T>
                {
                    IsSuccess = false,
                    ResponseMethod = "Update",
                    Message = "Error Occured: " + e.Message,
                    Data = null
                };
            }
        }
    }
}
