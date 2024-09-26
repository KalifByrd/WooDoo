using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CustomTag : MonoBehaviour 
{
    [SerializeField]
    public List<string> tags = new List<string>();
    
    public bool HasTag(string tag)
    {
        return tags.Contains(tag);
    }
    
    public IEnumerable<string> GetTags()
    {
        return tags;
    }

    
    
    public void Rename(int index, string tagName)
    {
        tags[index] = tagName;
    }

    public void AddTag(string tag)
    {
        tags.Add(tag);
    }

    public void RemoveTag(string tag)
    {
        tags.Remove(tag);
    }
    
    public string GetAtIndex(int index)
    {
        return tags[index];
    }
    
    public int Count
    {
        get { return tags.Count; }
    }
}