﻿using System;
using CookComputing.XmlRpc;
using WordPressSharp.Models;

namespace WordPressSharp
{
    public class WordPressClient : IDisposable
    {
        protected WordPressSiteConfig WordPressSiteConfig { get; set; }

        public IWordPressService WordPressService { get; internal set; }

        public WordPressClient(WordPressSiteConfig siteConfig)
        {
            WordPressSiteConfig = siteConfig;

            WordPressService = (IWordPressService) XmlRpcProxyGen.Create(typeof (IWordPressService));
            WordPressService.Url = WordPressSiteConfig.FullUrl;
        }

        public Post GetPost(int postId)
        {
            return WordPressService.GetPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, postId);
        }

        public Post[] GetPosts(PostFilter postFilter)
        {
            return WordPressService.GetPosts(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username,
                WordPressSiteConfig.Password, postFilter);
        }

        public string NewPost(Post post)
        {
            return WordPressService.NewPost(WordPressSiteConfig.BlogId, WordPressSiteConfig.Username, WordPressSiteConfig.Password, post);
        }

        public void Dispose()
        {
            WordPressService = null;
        }
    }
}
