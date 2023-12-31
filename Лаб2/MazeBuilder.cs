﻿using Library;
using Лаб1;

namespace Лаб2
{
    public class MazeBuilder
    {
        protected Maze Maze { get; }
       
        public MazeBuilder()
        {
            Maze = new();
        }

        public Maze GetMaze()
        {
            return Maze;
        }

        public virtual void BuildRoom(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), number, "Number не может быть отрицательным.");
            }
            Room room = CreaateRoom(number);
            ArgumentNullException.ThrowIfNull(room);
           
            Maze.AddRoom(room);
            room.SetSide(Direction.North, new Wall());
            room.SetSide(Direction.South, new Wall());
            room.SetSide(Direction.West, new Wall());
            room.SetSide(Direction.East, new Wall());
        }

        public virtual void BuildDoor(int room1, int room2)
        {
            var r1= Maze.RoomNo(room1);
            var r2 = Maze.RoomNo(room2);
            ArgumentNullException.ThrowIfNull(r1);
            ArgumentNullException.ThrowIfNull(r2);
            Door door = CreaateDoor(r1 , r2);
            r1.SetSide(Direction.East, door);
            r2.SetSide(Direction.West, door);
        }

        public virtual Wall BuildWall()
        {
            return new Wall();
        }

        protected virtual Room CreaateRoom(int number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number), number, "Number не может быть отрицательным.");
            }
            return new Room(number);
        }

        protected virtual Door CreaateDoor(Room room1, Room room2)
        {
            ArgumentNullException.ThrowIfNull(room1);
            ArgumentNullException.ThrowIfNull(room2);
            return new Door(room1, room2);
        }

    }
}
