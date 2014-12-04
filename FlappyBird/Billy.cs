using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace BillyDemon
{
	public class Billy
	{
		//Private variables.
		private static SpriteUV 	sprite;
		private static TextureInfo	textureInfo;
		//private static int			pushAmount = 100;
		//private static float		yPositionBeforePush;
		private static bool			moveRight;
		private static bool			moveLeft;
		private static bool			alive;
		private static float          speed;
		private static Vector2		playerDirection;
	  
		
		public bool Alive { get{return alive;} set{alive = value;} }
		
		//Accessors.
		//public SpriteUV Sprite { get{return sprite;} }
		 
		// Sets up our game pad
		GamePadData gamePadData;
		public GamePadData PadData 
		{ 
			get { return gamePadData;}
		}
		
		//Public functions.
		public Billy (Scene scene)
		{
			textureInfo  = new TextureInfo("/Application/textures/DemonPlaceholder.png");
			
			sprite	 		= new SpriteUV();
			sprite 			= new SpriteUV(textureInfo);	
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = new Vector2(50.0f,Director.Instance.GL.Context.GetViewport().Height*0.5f);
			//sprite.Pivot 	= new Vector2(0.5f,0.5f);
			//angle = 0.0f;
			//rise  = false;
			alive = true;
			speed = 0.3f;
			
			
			//Add to the current scene.
			scene.AddChild(sprite);
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();
		}
		
		public void Update(float deltaTime)
		{		
			playerDirection = new Vector2(0.0f,0.0f);
			
			gamePadData = GamePad.GetData(0);
			
			// If we move left
			if((gamePadData.Buttons & GamePadButtons.Left) != 0)
			{
				// Changes which way the player is facing.
				playerDirection = new Vector2(-1.0f,0.0f);
				//bulletDirection = new Vector2(-1.0f,0.0f);
				// If the sprite is within the left of the screen, move. Else, do not move.
				if(sprite.Position.X < 0)
				{
					playerDirection = new Vector2(0.0f, 0.0f);
				}
			}
			
			// If we move right
			if((gamePadData.Buttons & GamePadButtons.Right) != 0)
			{
				playerDirection = new Vector2(1.0f,0.0f);
				//bulletDirection = new Vector2(1.0f,0.0f);
				// If the sprite is within the right of the screen, move. Else, do not move.
				if((sprite.Position.X + sprite.TextureInfo.TileSizeInPixelsf.X) > (Director.Instance.GL.Context.GetViewport().Width))
				{
					playerDirection = new Vector2(0.0f, 0.0f);
				}
			}
			
			// If we move up
			if((gamePadData.Buttons & GamePadButtons.Up) != 0)
			{
				playerDirection = new Vector2(0.0f,1.0f);
				//bulletDirection = new Vector2(0.0f,1.0f);
				
				if((sprite.Position.Y + sprite.TextureInfo.TileSizeInPixelsf.Y) > Director.Instance.GL.Context.GetViewport().Height)
				{
					playerDirection = new Vector2(0.0f, 0.0f);
				}
			}
			
			// If we move down
			if((gamePadData.Buttons & GamePadButtons.Down) != 0)
			{
				playerDirection = new Vector2(0.0f,-1.0f);
				//bulletDirection = new Vector2(0.0f,-1.0f);
				
				if((sprite.Position.Y) < 0)
				{
					playerDirection = new Vector2(0.0f, 0.0f);
				}
				
				
			}
			
			sprite.Position += playerDirection * speed;
				
//			if(Input2.GamePad.GetData(0).Left)
//   		   	{
//				sprite.Position.X +=speed;
//			}
		
//			
//			data = GamePad.GetData(0);
//			
//			if((data.Buttons & GamePadButtons.Left)!= 0)
//			{
//				sprite.Position.X -= speed;
//			}
//			if((data.Buttons & GamePadButton.Right)!= 0)
//			{
//				sprite.Position.X +=speed;
//			}
			
			//adjust the push
			//if(moveRight)
			//{
			//	//sprite.Rotate(0.008f);
			//	if( (sprite.Position.Y-yPositionBeforePush) < pushAmount)
			//		sprite.Position = new Vector2(sprite.Position.X + 1f, sprite.Position.Y);
			//	else
			//		moveRight = false;
		//	}
		//	else
		//	{
		//		//sprite.Rotate(-0.005f);
				//sprite.Position = new Vector2(sprite.Position.X, sprite.Position.Y - 3);
		//	}
		}
		
		public void Tapped()
		{
//			//if(!rise)
//			//{
//			//	rise = true;
//			//	yPositionBeforePush = sprite.Position.Y;
//			//}
		}
	}
}


