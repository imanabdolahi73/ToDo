using Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Common;

namespace ToDo.Application.Services.Task
{
    public interface ITaskManagementService
    {
        ResultDto Add(Add_Task_Dto request);
        ResultDto Edit(Edit_Task_Dto request);
        ResultDto ChangeStatus(ChangeStatus_Task_Dto request);
        ResultDto Remove(int TaskID , int UserID);
        ResultDto<List<Domain.Entities.Task>> List(int? UserID);
    }
    public class TaskManagementService : ITaskManagementService
    {
        private readonly IToDoContext _context;
        public TaskManagementService(IToDoContext context)
        {
            _context = context;
        }

        public ResultDto Add(Add_Task_Dto request)
        {
            try
            {
                _context.Tasks.Add(new Domain.Entities.Task()
                {
                    InsertDateTime = DateTime.Now,
                    UserId = request.UserId,
                    IsRemoved = false,
                    StatusId = request.StatusId,
                    Title = request.Title,
                    
                });
                _context.SaveChanges();

                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "Success!",
                };
            }
            catch (Exception e)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = e.Message,
                };
            }
        }

        public ResultDto Edit(Edit_Task_Dto request)
        {
            try
            {
                Domain.Entities.Task task = _context.Tasks
                    .Where(p => p.TaskId == request.TaskId)
                    .First();

                if (request.UserId == task.UserId)
                {
                    task.Title = request.Title;
                    task.UpdateDateTime = DateTime.Now;

                    _context.SaveChanges();
                    return new ResultDto()
                    {
                        IsSuccess = true,
                        Message = "Success!",
                    };
                }
                else
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "Access limit!",
                    };
                }
                
            }
            catch (Exception e)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = e.Message,
                };
            }
        }

        public ResultDto ChangeStatus(ChangeStatus_Task_Dto request)
        {
            try
            {
                Domain.Entities.Task task = _context.Tasks
                    .Where(p => p.TaskId == request.TaskId)
                    .First();

                if (request.UserId == task.UserId)
                {
                    task.StatusId = request.StatusID;
                    task.UpdateDateTime = DateTime.Now;

                    _context.SaveChanges();
                    return new ResultDto()
                    {
                        IsSuccess = true,
                        Message = "Success!",
                    };
                }
                else
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "Access limit!",
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = e.Message,
                };
            }
        }

        public ResultDto Remove(int TaskID , int UserID)
        {
            try
            {
                Domain.Entities.Task task = _context.Tasks
                    .Where(p => p.TaskId == TaskID)
                    .First();

                if (UserID == task.UserId)
                {
                    task.RemoveDateTime = DateTime.Now;
                    task.IsRemoved = true;

                    _context.SaveChanges();
                    return new ResultDto()
                    {
                        IsSuccess = true,
                        Message = "Success!",
                    };
                }
                else
                {
                    return new ResultDto()
                    {
                        IsSuccess = false,
                        Message = "Access limit!",
                    };
                }
            }
            catch (Exception e)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = e.Message,
                };
            }
        }

        public ResultDto<List<Domain.Entities.Task>> List(int? UserID)
        {
            List<Domain.Entities.Task> tasks = new List<Domain.Entities.Task> ();
            try
            {
                if (UserID is null)
                {
                    tasks = _context.Tasks.ToList();
                }
                else
                {
                    tasks = _context.Tasks.Where(p => p.UserId == UserID).ToList();
                }

                if (tasks.Count != 0)
                {
                    return new ResultDto<List<Domain.Entities.Task>>
                    {
                        Data = tasks,
                        IsSuccess = true,
                        Message = "Success"
                    };

                }
                else
                {
                    return new ResultDto<List<Domain.Entities.Task>>
                    {
                        Data = tasks,
                        IsSuccess = false,
                        Message = "Not found"
                    };

                }
            }
            catch (Exception e)
            {
                return new ResultDto<List<Domain.Entities.Task>>
                {
                    Data = tasks,
                    IsSuccess = false,
                    Message = e.Message
                };
            }
        }


    }

    public class Add_Task_Dto
    {
        public string Title { get; set; } = null!;

        public int UserId { get; set; }

        public int StatusId { get; set; }
    }

    public class Edit_Task_Dto
    {
        public int TaskId { get; set; }
        public string Title { get; set; } = null!;
        public int UserId { get; set; }

    }
    public class ChangeStatus_Task_Dto
    {
        public int TaskId { get; set; }
        public int StatusID { get; set; }
        public int UserId { get; set; }
    }
}
