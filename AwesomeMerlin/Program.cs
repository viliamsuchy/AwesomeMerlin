using AwesomeMerlin.Actors;
using AwesomeMerlin.Commands;
using AwesomeMerlin.Factories;
using AwesomeMerlin.Spell;
using Merlin2d.Game;
using Merlin2d.Game.Actors;
using Merlin2d.Game.Enums;
using System;

namespace AwesomeMerlin
{
    class Program
    {
        static void Main(string[] args)
        {


            GameContainer container = new GameContainer("The most awesome Merlin Project", 1920, 1080);
            container.SetMap("resources/maps/house.tmx");
            container.GetWorld().SetFactory(new ActorFactory());
            container.GetWorld().SetPhysics(new Gravity());
            IWorld world = container.GetWorld();
            Action<IWorld> put = world =>
            {
                Switch switch1 = (Switch)world.GetActors().Find(a => a is Switch);
                Door door1 = (Door)world.GetActors().Find(a => a is Door);
                switch1.Subscribe(door1);
            };
            Message Won = new Message("CONGRATULATION! YOU WON THAT GAME!", 500, 500, 50, Color.Red, (MessageDuration)1);
            Message Lost = new Message("OOOPS! TRY AGAIN LATER!", 600, 500, 50, Color.Red, (MessageDuration)1);
            container.SetEndGameMessage(Won,MapStatus.Finished);
            container.SetEndGameMessage(Lost,MapStatus.Failed);
            world.AddInitAction(put);
            




            // container.GetWorld().SetFactory(new ActorFactorycs());
            //IWorld world = container.GetWorld();
            //Player player = new Player();
            //player.OnAddedToWorld(world);
            //player.SetPosition(400, 400);
            //player.SetName("player");
            //Console.WriteLine(player.GetName());
            //player = (Player)world.GetActors().Find(x => x.GetName() == "player");
            //container.GetWorld().AddInitAction(w =>
            //{

            //    // w.GetActors().Find(x => x.GetName() == "player");
            //    //Player actor =(Player)w.GetActors().Find(x => x.GetName() == "player");
            //    //if(actor == null)
            //    //{
            //    //    Console.WriteLine("nejdes");
            //    //}
            // Player actor = new Player();
            //player = (Player)world.GetActors().Find(x => x.GetName() == "player");
            //    actor.SetPosition(400, 400);
            //Console.WriteLine(player.GetName());
            //    w.AddActor(actor);
            //    ;
            //    //    actor.SetPhysics(true);



            //});
            //container.GetWorld().AddInitAction(w =>
            //{
            //    IActor actor = new Skeleton();
            //    actor.SetPosition(400, 400);
            //    w.AddActor(actor);
            //    actor.SetPhysics(true);




            //});





            //Enemy enemy = new Enemy();
            //container.GetWorld().AddActor(enemy);
            //container.AddActor(new Enemy());
            //container.AddActor(new Enemy("alalal"));
            //container.GetWorld().SetFactory(factory);
            //container.GetWorld()


            //container.GetWorld().SetPhysics(new Gravity());
            //container.GetWorld().AddActor(enemy);

            //enemy.SetPhysics(true);
            //Player player = new Player();
            //container.GetWorld().AddActor(player);


            container.Run();
            
        }
    }
}
