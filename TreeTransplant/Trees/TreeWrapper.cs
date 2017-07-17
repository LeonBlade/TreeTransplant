using StardewValley;
using StardewValley.TerrainFeatures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewModdingAPI;

namespace TreeTransplant
{
	public class TreeWrapper : ITree
	{
		private IModHelper Helper;
		private Tree tree;

		public TreeWrapper(IModHelper helper, Tree t)
		{
			Helper = helper;
			tree = t;
		}

		public TerrainFeature getTerrainFeature()
		{
			return tree;
		}

		public Texture2D texture
		{
			get 
			{
				if (isAdult() && !tree.stump)
					return TreeTransplant.treeTexture;
				return Helper.Reflection.GetPrivateField<Texture2D>(tree, "texture").GetValue(); 
			}
		}

		public bool flipped
		{
			get { return tree.flipped; }
			set { tree.flipped = value; }
		}

		public int treeType
		{
			get { return tree.treeType; }
		}

		public Rectangle treeTopSourceRect
		{
			get 
			{
				if (!isAdult())
				{
					Rectangle rect;
					switch (tree.growthStage)
					{
						// seed
						case 0:
							rect = new Rectangle(32, 128, 16, 16);
							break;
						// sprout
						case 1:
							rect = new Rectangle(0, 128, 16, 16);
							break;
						// full sprout
						case 2:
							rect = new Rectangle(16, 128, 16, 16);
							break;
						// mini tree
						default:
							rect = new Rectangle(0, 96, 16, 32);
							break;
					}
					return rect;
				}

				int season = Utility.getSeasonNumber(Game1.currentSeason);
				return new Rectangle(48 * (tree.treeType - 1), season * 96, 48, 96);
			}
		}

		public Rectangle stumpSourceRect
		{
			get { return Tree.stumpSourceRect; }
		}

		public Rectangle getBoundingBox(Vector2 tileLocation)
		{
			return tree.getBoundingBox(tileLocation);
		}

		public bool stump
		{
			get { return tree.stump; }
		}

		public bool isAdult()
		{
			return tree.growthStage > 4;
		}

		public bool isStumpSeparate()
		{
			return isAdult();
		}
	}
}
