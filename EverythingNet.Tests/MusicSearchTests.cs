﻿using EverythingNet.Core;
using EverythingNet.Extensions;
using NUnit.Framework;

namespace EverythingNet.Tests
{
  [TestFixture]
  public class MusicSearchTests
  {
    private Everything everyThing;

    [SetUp]
    public void Setup()
    {
      this.everyThing = new Everything();
    }

    [TearDown]
    public void TearDown()
    {
      this.everyThing.CleanUp();
    }

    [TestCase(null, ExpectedResult = "album:")]
    [TestCase("", ExpectedResult = "album:")]
    [TestCase("The Wall", ExpectedResult = "album:The Wall")]
    public string Album(string album)
    {
      IEverything everything = new Everything();

      everything.Album(album);

      return everything.SearchText;
    }

    [Test(ExpectedResult = "album:")]
    public string Album2()
    {
      IEverything everything = new Everything();

      everything.Album();

      return everything.SearchText;
    }

    [TestCase(null, ExpectedResult = "artist:")]
    [TestCase("", ExpectedResult = "artist:")]
    [TestCase("Pink Floyed", ExpectedResult = "artist:Pink Floyed")]
    public string Artist(string artist)
    {
      IEverything everything = new Everything();

      everything.Artist(artist);

      return everything.SearchText;
    }

    [Test(ExpectedResult = "artist:")]
    public string Artist2()
    {
      IEverything everything = new Everything();

      everything.Artist();

      return everything.SearchText;
    }

    [TestCase(0, 5, ExpectedResult = "track:0-5")]
    [TestCase(2, 7, ExpectedResult = "track:2-7")]
    public string Track(int min, int max)
    {
      IEverything everything = new Everything();

      everything.Track().Between(min, max);

      return everything.SearchText;
    }
  }
}