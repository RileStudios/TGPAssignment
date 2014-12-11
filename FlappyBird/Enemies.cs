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
		
		private static SpriteUV[] 	spriteBunnies;
		private static TextureInfo	textureInfoBunny;
		private static bool			aliveBunny;
		private static float        speed;
		
		  
		
		public Enemies (Scene scene)
		{
			textureInfoBunny  = new TextureInfo("/Application/textures/DemonPlaceholder.png");
			
			spriteBunnies = new SpriteUV[4];
			
			//bunny 1
			spriteBunnies[0] = new SpriteUV(textureInfoBunny);
			spriteBunnies[0].Quad.S 	= textureInfoBunny.TextureSizef;
			//bunny 2
			spriteBunnies[1] = new SpriteUV(textureInfoBunny);
			spriteBunnies[1].Quad.S 	= textureInfoBunny.TextureSizef;
			//bunny 3
			spriteBunnies[2] = new SpriteUV(textureInfoBunny);
			spriteBunnies[2].Quad.S 	= textureInfoBunny.TextureSizef;
			//bunny 4
			spriteBunnies[3] = new SpriteUV(textureInfoBunny);
			spriteBunnies[3].Quad.S 	= textureInfoBunny.TextureSizef;
			//bunny 5
			spriteBunnies[4] = new SpriteUV(textureInfoBunny);
			spriteBunnies[4].Quad.S 	= textureInfoBunny.TextureSizef;
			
			//Enemy positions
			spriteBunnies[0].Position = new Vector2( 30.0f,
			                          Director.Instance.GL.Context.GetViewport().Height*RandomPosition());
			
			spriteBunnies[1].Position = new Vector2( 40.0f,
			                          Director.Instance.GL.Context.GetViewport().Height*RandomPosition());
			
			spriteBunnies[2].Position = new Vector2( 10.0f,
			                          Director.Instance.GL.Context.GetViewport().Height*RandomPosition());
			
			spriteBunnies[3].Position = new Vector2( 15.0f,
			                          Director.Instance.GL.Context.GetViewport().Height*RandomPosition());
			
			spriteBunnies[4].Position = new Vector2( 5.0f,
			                          Director.Instance.GL.Context.GetViewport().Height*RandomPosition());
			
			//Add it to the scene
			scene.AddChild(spriteBunnies);
			
		}
		
		public void Dispose()
		{
			textureInfoBunny.Dispose();
		}
		
		private float RandomPosition()
		{
			Random rand = new Random();
			float randomPosition = (float)rand.NextDouble();
			randomPosition += 0.45f;
			
			if(randomPosition > 1.0f)
				randomPosition = 0.9f;
		
			return randomPosition;
		}
	}
}

