using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;


namespace BillyDemon
{
	public class Enemies
	{
		
		private 		SpriteUV[] 	spriteBunnies;
		private 		TextureInfo	textureInfoBunny;
		private bool	aliveBunny;
		private float   bunnySpeed;
		private 		Sce.PlayStation.HighLevel.GameEngine2D.Base.Math.RandGenerator randomPosition;
		
		  
		
		public Enemies (Scene scene)
		{
			
			randomPosition = new Sce.PlayStation.HighLevel.GameEngine2D.Base.Math.RandGenerator(DateTime.Now.Millisecond);
			textureInfoBunny  = new TextureInfo("/Application/textures/Bunny.png");
			
			spriteBunnies = new SpriteUV[5];
			
			for(int i =0;i<=4;i++)
			{
			//Set bunny textures
			spriteBunnies[i] = new SpriteUV(textureInfoBunny);
			spriteBunnies[i].Quad.S 	= textureInfoBunny.TextureSizef;
			}
			
			//Enemy positions
			for(int i =0;i<=4;i++)
			{
			spriteBunnies[i].Position = new Vector2(randomPosition.NextFloat(0, Director.Instance.GL.Context.GetViewport().Width - textureInfoBunny.TextureSizef.X), 
			                              randomPosition.NextFloat(0, Director.Instance.GL.Context.GetViewport().Height - textureInfoBunny.TextureSizef.Y));
			}
			
			//Add it to the scene
			for(int i =0;i<=4;i++)
			{
			scene.AddChild(spriteBunnies[i]);
			}
		}
		
		public void Dispose()
		{
			textureInfoBunny.Dispose();
		}
	}
}

