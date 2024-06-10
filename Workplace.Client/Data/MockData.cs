﻿using Workplace.Shared;

namespace Workplace.Client.Data
{
    public class MockData : IDataService
    {
        private readonly List<TaskItemDTO> tasks = [
            new TaskItemDTO() {
                Id = 1,
                Name = "Задача 1",
                Theme = "Тема 1",
                Description = "Описание 1",
                StartTime = DateTime.Now.AddDays(1),
                EndTime = DateTime.Now.AddDays(2)
            },
            new TaskItemDTO() {
                Id = 2,
                Name = "Задача 2",
                Theme = "Тема 2",
                Description = "Описание 2",
                StartTime = DateTime.Now.AddDays(2),
                EndTime = DateTime.Now.AddDays(3)
            },
            new TaskItemDTO() {
                Id = 3,
                Name = "Задача 3",
                Theme = "Тема 3",
                Description = "Описание 3",
                StartTime = DateTime.Now.AddDays(3),
                EndTime = DateTime.Now.AddDays(4)
            },
        ];

        public async Task UpdateAsync(TaskItemDTO taskItem)
        {
            await Task.Run(() =>
            {
                if (taskItem.Id != 0)
                {
                    var task = tasks.First(x => x.Id == taskItem.Id);
                    tasks.Remove(task);
                }
                else
                {
                    taskItem.Id = tasks.Max(t => t.Id) + 1;
                }
                tasks.Add(taskItem);
            });
        }

        public async Task<IEnumerable<TaskItemDTO>> GetAllAsync()
        {
            return await Task.FromResult<IEnumerable<TaskItemDTO>>(tasks.OrderBy(task => task.StartTime));
        }

        public async Task<TaskItemDTO> GetTaskItemAsync(int Id)
        {
            return await Task.FromResult<TaskItemDTO>(tasks.First(x => x.Id == Id));
        }

        public async Task DeleteAsync(int Id)
        {
            await Task.Run(() => tasks.Remove(tasks.First(x => x.Id == Id)));
        }
    }
}
