using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationRobotMovementAppWF.Classes
{
    public class Graph
    {
        // Кол-во узлов в графе
        private int countNode;

        // Список смежности
        private List<int>[] adjacencyList;

        // Полученный список
        private List<int> _path = new List<int>();

        // Пересекающаяся вершина
        private int _intersectNode = -1;

        public Graph(int countNode)
        {
            this.countNode = countNode;
            adjacencyList = new List<int>[countNode];
            // Заполнение списка
            for (int i = 0; i < countNode; i++)
            {
                adjacencyList[i] = new List<int>();
            }
        }

        // Добавление неориентированного ребра
        public void AddEdge(int parentNode, int childNode)
        {
            // Добавления обоих вариантов
            adjacencyList[parentNode].Add(childNode);
            adjacencyList[childNode].Add(parentNode);
        }

        // Метод поиска в ширину
        private void BFS(Queue<int> queue, bool[] visited, int[] parent)
        {
            // Первый элемент очереди
            int currentNode = queue.Dequeue();
            foreach (int item in adjacencyList[currentNode])
            {
                // Если соседняя вершина не отмечалась, отмечаем как посещённую
                if (!visited[item])
                {
                    // Устанавливаем текущий элемент в качестве родительского для этой вершины
                    parent[item] = currentNode;
                    // Отмечаем посещенной
                    visited[item] = true;
                    // Перемещаем в конец очереди
                    queue.Enqueue(item);
                }
            }
        }

        // Проверка пересекающихся вершин
        private int IsIntersecting(bool[] startVisited, bool[] finishVisited)
        {
            for (int i = 0; i < countNode; i++)
            {
                // Если вершина посещена обоими поисками, возвращаем её, иначе -1
                if (startVisited[i] && finishVisited[i])
                    return i;
            }
            return -1;
        }

        // Метод формирования пути
        private void formationPath(int[] startParent, int[] finishParent, int startIndex, int finishIndex, int intersectNode)
        {
            _path.Add(intersectNode);
            int item = intersectNode;

            // Для прямого
            while (item != startIndex)
            {
                _path.Add(startParent[item]);
                item = startParent[item];
            }
            _path.Reverse();

            item = intersectNode;
            // Для обратного
            while (item != finishIndex)
            {
                _path.Add(finishParent[item]);
                item = finishParent[item];
            }
        }

        // Метод вывода пути (консоль)
        public void paintPath()
        {
            Console.WriteLine("---* Путь *---");
            string strPath = "";
            foreach (int i in _path)
            {
                strPath += i + " ";
            }
            Console.WriteLine(strPath);
        }

        // Метод для возврата пути
        public List<int> getPath()
        {
            return _path;
        }

        // Метод двунаправленного поиска
        public int BiDirSearch(int startIndex, int finishIndex)
        {
            // Массивы для отслеживания посещённых узлов
            bool[] startVisited = new bool[countNode];
            bool[] finishVisited = new bool[countNode];

            // Массивы для отслеживания родительских узлов
            int[] startParent = new int[countNode];
            int[] finishParent = new int[countNode];

            // Очереди для обоих поисков
            Queue<int> startQueue = new Queue<int>();
            Queue<int> finishQueue = new Queue<int>();

            // Индекс пересекающегося узла
            int intersectNode = -1;

            // Необходимая инициализация
            for (int i = 0; i < countNode; i++)
            {
                startVisited[i] = false;
                finishVisited[i] = false;
            }

            // Задаём переданные вершины

            // Прямой поиск
            // Добавляение в конец очереди
            startQueue.Enqueue(startIndex);
            // Статус посещения вершины
            startVisited[startIndex] = true;
            // Родительский элемент источника
            startParent[startIndex] = -1;

            // Обратный поиск
            // Добавляение в конец очереди
            finishQueue.Enqueue(finishIndex);
            // Статус посещения вершины
            finishVisited[finishIndex] = true;
            // Родительский элемент источника
            finishParent[finishIndex] = -1;

            // Цикл перебора элементов очереди
            while (startQueue.Count > 0 && finishQueue.Count > 0)
            {
                // Выполняем поиск в ширину в обе стороны
                BFS(startQueue, startVisited, startParent);
                BFS(finishQueue, finishVisited, finishParent);

                // Проверка пересечения вершин
                intersectNode = IsIntersecting(startVisited, finishVisited);

                // Если найдена пересекающаяся вершина путь найден
                if (intersectNode != -1)
                {
                    // Console.WriteLine("Путь существует между {0} и {1}", startIndex, finishIndex);
                    // Console.WriteLine("И пересекается в: {0} вершине", intersectNode);
                    this.intersectNode = intersectNode;

                    // Формирование пути
                    formationPath(startParent, finishParent, startIndex, finishIndex, intersectNode);
                    // Вывод пути в консоль
                    // paintPath();
                    return 0;
                }
            }
            return -1;
        }

        // Возвращает номер смежной вершины
        public int intersectNode 
        {
            get 
            {
                return _intersectNode;
            }
            set 
            {
                _intersectNode = value;
            } 
        }
    }
}
