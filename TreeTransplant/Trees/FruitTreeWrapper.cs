using StardewValley;
using StardewValley.TerrainFeatures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TreeTransplant
{
	public class FruitTreeWrapper : ITree
	{
		private FruitTree tree;

		public FruitTreeWrapper(FruitTree fruitTree)
		{
			tree = fruitTree;
		}

		public TerrainFeature getTerrainFeature()
		{
			return tree;
		}

		public Texture2D texture
		{
			get { return FruitTree.texture; }
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
				bool adult = tree.growthStage > 3;
				int season = Utility.getSeasonNumber(Game1.currentSeason);

				return new Rectangle(
					tree.growthStage * 48 + (adult ? season * 48 : 4), // offset the small trees because idk
					tree.treeType * 80, 
					48, 
					80
				); 
			}
		}

		public Rectangle stumpSourceRect
		{
			get { return new Rectangle(384, (tree.treeType * 80) + 56, 48, 24); }
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
			return tree.growthStage > 3;
		}

		public bool isStumpSeparate()
		{
			return false;
		}
	}
}
