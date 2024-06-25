using System.Threading.Tasks;
using Workplace.Shared.Schedule;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Workplace.Client.Data.Schedule
{
    public class ScheduleMockData : IScheduleDataService
    {
        public readonly List<ScheduleItem> data = [
            new ScheduleItem() {
                TimeSpending = new DateTime(2024, 6, 25, 9, 45, 0),
                LessonInfo = new Lesson() {
                    Id = 0,
                    Name = "Физическая культура",
                    Teachers = [
                        "Не придумал Иванович",
                        "Кто-то Александрович",
                        "Альберт Эйнштейн"
                    ]
                },
                LT = LessonType.Практика,
                Location = "ул.Пушкина, д.Колотушкина",
                Groups = [
                    new Group() {
                        Id = 0,
                        Name = "МКМб 22-1",
                        Students = [
                            new Student() {
                                Id = 0,
                                Name = "Ваня Дырка"
                            },
                            new Student() {
                                Id = 1,
                                Name = "Вася Пупкин"
                            },
                            new Student() {
                                Id = 2,
                                Name = "Даздраперма Василькова"
                            },
                            new Student() {
                                Id = 3,
                                Name = "Иосиф Сталин"
                            },
                            new Student() {
                                Id = 4,
                                Name = "Олег Тиньков"
                            },
                            new Student() {
                                Id = 5,
                                Name = "Т-Банк Сбербанкович"
                            }
                        ]
                    },
                    new Group() {
                        Id = 1,
                        Name = "ПКТб 22-1",
                        Students = [
                            new Student() {
                                Id = 6,
                                Name = "Джон Доу"
                            },
                            new Student() {
                                Id = 7,
                                Name = "Джейн Доу"
                            },
                            new Student() {
                                Id = 8,
                                Name = "Кристофер Нолан"
                            },
                            new Student() {
                                Id = 9,
                                Name = "Стивен Спилберг"
                            },
                            new Student() {
                                Id = 10,
                                Name = "Саша Спилберг"
                            },
                            new Student() {
                                Id = 11,
                                Name = "Ян Гордиенко"
                            }
                        ]
                    }]
            },
            new ScheduleItem() {
                TimeSpending = new DateTime(2024, 6, 26, 8, 0, 0),
                LessonInfo = new Lesson() {
                    Id = 2,
                    Name = "Безопасность жизнедеятельности",
                    Teachers = [
                        "Не придумал Иванович",
                        "Кто-то Александрович",
                        "Альберт Эйнштейн"
                    ]
                },
                LT = LessonType.Лекция,
                Location = "ул.Пушкина, д.Колотушкина",
                Groups = [new Group() {
                    Id = 0,
                    Name = "МКМб 22-1",
                    Students = [
                        new Student() {
                            Id = 0,
                            Name = "Ваня Дырка"
                        },
                        new Student() {
                            Id = 1,
                            Name = "Вася Пупкин"
                        },
                        new Student() {
                            Id = 2,
                            Name = "Даздраперма Василькова"
                        },
                        new Student() {
                            Id = 3,
                            Name = "Иосиф Сталин"
                        },
                        new Student() {
                            Id = 4,
                            Name = "Олег Тиньков"
                        },
                        new Student() {
                            Id = 5,
                            Name = "Т-Банк Сбербанкович"
                        }
                    ]
                }]
            },
        ]; 

        public async Task<List<ScheduleItem>> GetDayAsync(DateTime dayDate)
        {
            return await Task.FromResult<List<ScheduleItem>>(data.Where(i => i.TimeSpending.Date.CompareTo(dayDate.Date) == 0).ToList());
        }

        public async Task<List<ScheduleItem>> GetDayRangeAsync(DateTime border1, DateTime border2, string? studentName)
        {
            if (studentName == string.Empty || studentName == null)
                return await Task.FromResult<List<ScheduleItem>>(data
                    .Where(i => i.TimeSpending.Date.CompareTo(border1.Date) >= 0 && i.TimeSpending.Date.CompareTo(border2.Date) <= 0)
                    .ToList());
            else
            {
                return await Task.FromResult<List<ScheduleItem>>(data
                    .Where(i => i.TimeSpending.Date.CompareTo(border1) >= 0 && i.TimeSpending.Date.CompareTo(border2) <= 0
                        && i.Groups!.Any(g => g.Students!.Any(std => std.Name == studentName)))
                    .ToList());
            }
        }
    }
}
