using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace kataraktaCS.Controls.kataraktaListView
{
    public class kataraktaListView : ListView
    {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(this.Handle, "explorer", null);
        }
        
        private ListViewItem _draggedItem;

        public kataraktaListView()
        {
            AllowDrop = true;

            ItemDrag += OnItemDrag;
            DragEnter += OnDragEnter;
            DragDrop += OnDragDrop;
        }

        private void OnItemDrag(object sender, ItemDragEventArgs e)
        {
            _draggedItem = (ListViewItem)e.Item;
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
                e.Effect = DragDropEffects.Move;
        }

        private void OnDragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(typeof(ListViewItem)) || _draggedItem == null)
                return;

            Point point = PointToClient(new Point(e.X, e.Y));
            ListViewItem targetItem = GetItemAt(point.X, point.Y);

            if (targetItem == null || targetItem == _draggedItem)
                return;

            int targetIndex = targetItem.Index;

            Items.Remove(_draggedItem);
            Items.Insert(targetIndex, _draggedItem);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (LabelEdit)
            {
                base.OnMouseDoubleClick(e);

                var hit = HitTest(e.Location);
                if (hit.Item != null)
                    hit.Item.BeginEdit();
            }
        }
    }
}
