﻿using System;
namespace Library
{
    public class Door : IMapSite
    {
        private readonly Room room1;
        private readonly Room room2;
        private readonly bool _isOpen;

        public Door(Room room1, Room room2)
        {
            ArgumentNullException.ThrowIfNull(room1);
            ArgumentNullException.ThrowIfNull(room2);
            this.room1 = room1;
            this.room2 = room2;
            _isOpen = true;
        }
       
        public virtual void Enter()
        {
            if (_isOpen)
            {
                Console.WriteLine("Дверь открыта, Вы проходите через дверь");
            }
            else
            {
                Console.WriteLine("Дверь закрыта, Вы не можете пройти.");
            }
        }
       
        public Room OtherSideFrom(Room room)
        {
            if (room.Number == room1.Number)
            {
                return room2;
            }
            else if (room.Number == room2.Number)
            {
                return room1;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        
    }
}
