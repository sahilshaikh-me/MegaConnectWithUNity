using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CG.Web.MegaApiClient;
using System.Linq;
using System;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Main();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Main()
    {
        MegaApiClient client = new MegaApiClient();
        client.Login("sahilshaikh@parallax.co.in", "Sah@9876987876");

        IEnumerable<INode> nodes = client.GetNodes();

        INode root = nodes.Single(x => x.Type == NodeType.Root);
        INode myFolder = client.CreateFolder("Upload", root);

        INode myFile = client.UploadFile("D://Spark ar/Lioyd Aug.glb", myFolder);
        Uri downloadLink = client.GetDownloadLink(myFile);
        Console.WriteLine(downloadLink);

        client.Logout();
    }
}
