using System;
using System.Collections.Generic;

namespace RepositoryLogic
{
    public class Repository : IRepository
    {
        private readonly Dictionary<string, decimal> _repository= new Dictionary<string, decimal>();

        private decimal _value;
        private string _id;

        public string Person { get; set; }

        public void Save(string id, string person, decimal value)
        {
            Person = person ?? throw new ArgumentException(nameof(person));
            _value = value;
            _id = id ?? throw new ArgumentException($"{nameof(id)}");
        }

        public string GetById(string id)
        {
            if (id == null)
            {
                throw new ArgumentException(nameof(id));
            }

            foreach (var item in _repository)
            {
                if (item.Key == id)
                {
                    return id[0].ToString();
                }
            }

            throw new ArgumentException(nameof(id));
        }

        public string GetPerson()
        {
            return Person;
        }

        public string GetId()
        {
            return _id;
        }

        public void Create()
        {
            _repository.Add(_id,_value);
        }

        public void Update(string id, decimal value)
        {
            foreach (var item in _repository)
            {
                if (item.Key==id)
                {
                    _repository[id] += value;
                    return;
                }
            }

            throw new ArgumentException(nameof(id));
        }
    }
}
