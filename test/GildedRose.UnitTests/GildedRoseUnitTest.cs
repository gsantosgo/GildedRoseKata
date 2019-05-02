using Xunit;
using FluentAssertions;
using System.Collections.Generic;

namespace GildedRose.UnitTests
{
    public class GildedRoseUnitTest
    {

        [Fact]
        public void degrades_quality_twices_when_the_sell_by_date_has_passed()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].Quality.Should().Be(8);
        }

        [Fact]
        public void check_the_quality_an_item_never_negative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].Quality.Should().Be(0);
        }

        [Fact]
        public void increases_the_quality_by_one_when_agedbrie_getting_older()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].Quality.Should().Be(11);
        }

        [Fact]
        public void check_the_quality_of_an_item_is_never_more_50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].Quality.Should().Be(50);
        }

        [Fact]
        public void not_decreases_the_quality_when_the_item_is_sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].Quality.Should().Be(50);
        }

        [Fact]
        public void not_decreases_the_sellin_when_the_item_is_sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 50 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].SellIn.Should().Be(0);
        }

        [Fact]
        public void increases_the_quality_by_2_when_the_item_is_baskstage_10days_less()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].Quality.Should().Be(12);
        }

        [Fact]
        public void increases_the_quality_by_3_when_the_item_is_baskstage_5days_less()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].Quality.Should().Be(13);
        }

        [Fact]
        public void drop_the_quality_to_0_after_the_concert()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].Quality.Should().Be(0);
        }

        /// <summary>
        /// Test to reach coverage 100%
        /// </summary>
        [Fact]
        public void increase_the_quality_by_2_when_the_item_is_agedbrie_and_sellin_is_0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10} };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].Quality.Should().Be(12);
        }

        /*
        [Fact]
        public void Test1()
        {
            Item[] items = new Item[] { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();


            items[0].Name.Should().Be("foo");

        }

        [Fact]
        public void Test2()
        {
            string name = "foo";
            int sellIn = 0;
            int quality = 0;

            string itemString = DoUpdateQuality(name, sellIn, quality); 
           
            itemString.Should().Be("foo, -1, 0");
        }

     
        [Fact]
        public void ShouldSellInDecrementByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);

            app.UpdateQuality();

            Items[0].SellIn.Should().Be(4);
        }


        private string DoUpdateQuality(string name, int sellIn, int quality)
        {
            Item[] items = new Item[] { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            GildedRose app = new GildedRose(items);
            app.UpdateQuality();

            return items[0].ToString(); 
        }
        */
    }
}
