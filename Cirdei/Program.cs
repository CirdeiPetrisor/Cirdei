using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using OpenTK.Platform;

namespace OpenTK_console_sample01
{
    class SimpleWindow : GameWindow
    {
        bool pressed=false;
        bool makeTriangleBig = false;

        public SimpleWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
        }

        private void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            
        }
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.Azure);

        }
        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyboardState keyboard = OpenTK.Input.Keyboard.GetState();
            MouseState mouse = OpenTK.Input.Mouse.GetState();


            if (keyboard[OpenTK.Input.Key.A])
            {
                pressed = true;
                

            }
            if (keyboard[OpenTK.Input.Key.D])
            {
                makeTriangleBig = true;
            }
            
            


            if (mouse[OpenTK.Input.MouseButton.Left])
            {
                // Ascundere comandată, prin clic de mouse - fără testare remanență.
               
            }
        }

        private void HandleKeyboard()
        {
            throw new NotImplementedException();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
           // GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            if (pressed == true)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                DrawTriangle();
                pressed = false;
            }
            


            if(makeTriangleBig==true)
            {
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                DrawTriangle2();

                makeTriangleBig = false;
            }
           




            SwapBuffers();
            Thread.Sleep(1);
            
            
        }
        private void DrawTriangle()
        {
            
            GL.Begin(PrimitiveType.Triangles);

            GL.Vertex2(0.0f, 0.2);
            GL.Color3(Color.Black);
            GL.Vertex2(-0.2f, -0.2);

            GL.Vertex2(0.2f, -0.2f);

            GL.Color3(Color.Red);


            GL.End();
        }
        private void DrawTriangle2()
        {
           
            GL.Begin(PrimitiveType.Triangles);

            GL.Vertex2(0.2f, 0.2f);
            GL.Color3(Color.Black);
            GL.Vertex2(0.0f, -0.2f);

            GL.Vertex2(0.4f, -0.2f);

            GL.Color3(Color.Red);


            GL.End();
        }


        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow example = new SimpleWindow())
            {
                example.Run(30.0, 0.0);
            }
        }
    }

}

