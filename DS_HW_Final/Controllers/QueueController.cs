using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructures.Controllers
{
    public class QueueController : Controller
    {
        // GET: Queue
        //declare variable
        //create new queue variable of type string
        static Queue<string> myQueue = new Queue<string>();
        bool checkSearch = true;
        private bool checkQueue;
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();



        public ActionResult Index()
        {
            //add this so that when page first loads we have something added to the queue
            ViewBag.MyQueue = myQueue;
            return View();
        }

        //Action Result that will add one item to the queue
        public ActionResult AddOne()
        {
            myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }

        //Action result that will add huge list of items to Queue
        public ActionResult HugeList()
        {
            //clears the queue
            myQueue.Clear();

            //loop to add 2000 new items to the Queue
            for (int i = 0; i < 2000; i++)
            {
                myQueue.Enqueue("New Entry " + (myQueue.Count + 1));
            }

            ViewBag.MyQueue = myQueue;
            return View("Index");
        }

        //action result that will display the Queue
        public ActionResult DisplayQueue()
        {
            ViewBag.MyQueue = myQueue;
            return View("DisplayQueue");
        }


        //action result that will delete items from the Queue
        public ActionResult DeleteQueue()
        {
            //use pop because it deletes most recent
            if (myQueue.Count == 0)
            {
                return View("NO");
            }
            else
            {
                myQueue.Dequeue();
                ViewBag.MyQueue = myQueue;
                return View("Index");
            }
            

        }


        //action result that will clear the Queue
        public ActionResult ClearQueue()
        {
            myQueue.Clear();
            ViewBag.MyQueue = myQueue;
            return View("Index");
        }


        //action result that will search the Queue
        public ActionResult SearchQueue()
        {

            
           
            
                //starts the stopwatch either way, only will if it is true
                //starts the stopwatch
                sw.Start();
                //Searches the Queue for New Entry 5
                checkQueue = myQueue.Contains("New Entry 5");

                if (checkQueue == true)
                {
                    ViewBag.Output = "Found entry \"New Entry 5\"!";

                    //stops the stopwatch
                    sw.Stop();

                    TimeSpan ts = sw.Elapsed;

                    ViewBag.StopWatch = ts;
                }

                else
                {
                    ViewBag.Output = "\"New Entry 5\" Not Found :(";
                }

            


            return View("SearchQueue");


            /*action result to return to the main menu
            public ActionResult Return()
            {
                return View()
            }
            */



        }
    }
}