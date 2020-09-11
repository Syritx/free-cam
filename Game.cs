using System;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace FreeCam
{
    public class Game : GameWindow {

        Camera camera;

        public Game(int width, int height)
            : base(width, height, GraphicsMode.Default, "Free Cam") {

            camera = new Camera(this as GameWindow);
            Run(60);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            var view = Matrix4.LookAt(camera.position, camera.position + camera.front, camera.up);
            GL.LoadMatrix(ref view);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            // rendering a cube
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(1.0, 0.5, 0);
            // FRONT
            GL.Vertex3(-10, 10,-10);
            GL.Vertex3( 10, 10,-10);
            GL.Vertex3( 10,-10,-10);
            GL.Vertex3(-10,-10,-10);

            GL.Color3(1.0, 1.0, 1.0);
            // BACK
            GL.Vertex3(-10, 10, 10);
            GL.Vertex3( 10, 10, 10);
            GL.Vertex3( 10,-10, 10);
            GL.Vertex3(-10,-10, 10);

            GL.Color3(1.0, 0.0, 0.0);
            // LEFT
            GL.Vertex3(-10, 10,-10);
            GL.Vertex3(-10, 10, 10);
            GL.Vertex3(-10,-10, 10);
            GL.Vertex3(-10,-10,-10);

            GL.Color3(0.0, 1.0, 0.0);
            // RIGHT
            GL.Vertex3( 10, 10,-10);
            GL.Vertex3( 10, 10, 10);
            GL.Vertex3( 10,-10, 10);
            GL.Vertex3( 10,-10,-10);

            GL.Color3(0.0, 0.0, 1.0);
            // TOP
            GL.Vertex3(-10, 10,-10);
            GL.Vertex3(-10, 10, 10);
            GL.Vertex3( 10, 10, 10);
            GL.Vertex3( 10, 10,-10);

            GL.Color3(1.0, 0.0, 1.0);
            // BOTTOM
            GL.Vertex3(-10,-10,-10);
            GL.Vertex3(-10,-10, 10);
            GL.Vertex3( 10,-10, 10);
            GL.Vertex3( 10,-10,-10);

            GL.End();

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();

            Matrix4 perspectiveMatrix =
                Matrix4.CreatePerspectiveFieldOfView(1, Width / Height, 1.0f, 2000.0f);

            GL.LoadMatrix(ref perspectiveMatrix);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.End();
            base.OnResize(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0, 0, 0, 0);
            GL.Enable(EnableCap.DepthTest);
            base.OnLoad(e);
        }
    }
}
