using System;
using System.Collections.Generic;

namespace Question
{
    public class Library
    {
        private List<LibraryResource> _resources;
        public Library()
        {
            _resources = new List<LibraryResource>();
        }

        public void AddResource(LibraryResource resource)
        {
            _resources.Add(resource);
        }

        public bool HasResource(string name)
        {
            foreach (LibraryResource resource in _resources)
            {
                if (resource.Name == name && resource.OnLoan == false)
                {
                    return true;
                }
            }
            return false;
        }

        public List<LibraryResource> Resources
        {
            get
            {
                return _resources;
            }
        }
    }
}

