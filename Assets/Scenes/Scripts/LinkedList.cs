using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedList : MonoBehaviour
{
    public class Node
    {
        public Transform waypoint;
        public Node next;

        public Node(Transform waypoint)
        {
            this.waypoint = waypoint;
            this.next = null;
        }
    }

    public class CustomLinkedList
    {
        public Node head;
        public Node tail;

        public void Add(Transform waypoint)
        {
            Node newNode = new Node(waypoint);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
                tail.next = head; // circular
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
                tail.next = head; // maintain circular
            }
        }

        public Node GetNext(Node current)
        {
            return current.next;
        }
    }
}
