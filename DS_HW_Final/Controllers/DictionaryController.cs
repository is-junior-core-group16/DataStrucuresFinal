using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures.Controllers
{
    public class DictionaryController : Controller
    {

        //declare variable
        //creat new Dictionary variable of type= string
        static Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        bool checkSearch = true;
        private bool checkDictionary;
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        static int index = 0;
        static string viewBag = "";


        // GET: Dictionary
        public ActionResult Index()
        {
            //add this so that when page first loads we have something added to the Dictionary
            ViewBag.MyDictionary = viewBag;

            return View("DisplayDictionary");
        }

        //Action Result that will add one item to the string
        public ActionResult AddOne()
        {
            index++;
            myDictionary.Add(index, "New Entry " + (myDictionary.Count + 1));
            viewBag += "<p>" + myDictionary[index] + "</p>"; //myDictionary.Values.ElementAt(index-1);   
            ViewBag.MyDictionary = viewBag;
            return View("DisplayDictionary");

        }

        //Action result that will add huge list of items to Dictionary
        public ActionResult HugeList()
        {
            //clears the Dictionary
            myDictionary.Clear();

            viewBag = null;

            //loop to add 2000 new items to the Dictionary
            for (index = 0; index < 2000; index++)
            {
                myDictionary.Add(++index, "New Entry " + (myDictionary.Count + 1));
                viewBag += "<p>" + myDictionary[index] + "</p>";
            }

            ViewBag.MyDictionary = viewBag;
            return View("DisplayDictionary");
        }

        //action result that will display the Dictionary
        public ActionResult DisplayDictionary()
        {
            ViewBag.MyDictionary = viewBag;
            return View("DisplayDictionary");
        }


        //action result that will delete items from the Dictionary
        public ActionResult DeleteDictionary()
        {
            viewBag = null;
            //use pop because it deletes most recent
            myDictionary.Remove(index);
            index = 0;
            foreach (string item in myDictionary.Values)
            {
                viewBag += "<p>" + item + "</p>";
                index++;
            }
            ViewBag.MyDictionary = viewBag;
            return View("DisplayDictionary");

        }


        //action result that will clear the Dictionary
        public ActionResult ClearDictionary()
        {
            myDictionary.Clear();
            viewBag = null;
            ViewBag.MyDictionary = viewBag;
            index = 0;
            return View("DisplayDictionary");
        }


        //action result that will search the Dictionary
        public ActionResult SearchDictionary()
        {
            sw.Start();

            viewBag = null;

            if (myDictionary.ContainsValue("New Entry 4"))
            {
                viewBag = "New Entry 4";

            }
            else
            {
                viewBag = "Not found!";
            }


            //loop to do all the work

            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            ViewBag.StopWatch = ts;
            ViewBag.MyDictionary = viewBag;
            return View("DisplayDictionary");
        }
    }
}