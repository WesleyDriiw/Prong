using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;

namespace Prong
{
    class Retangulo
    {
        public int x;
        public int y;
       
        public int largura;
        public int altura;


    }
 
    internal class Program : GameWindow
    {
        //variaveis
        //x e y da bola
        int pontos = 0;
        int pontos2 = 0;

        Retangulo bola1;
        Retangulo bola2;
    

        int vida1 = 5;
        int vida2 = 5;
        
        int somax;
        int somax2;
        int somay;
        int somay2;
        int spex;
        int spey;
        int spex2;
        int spey2;

        //sera para controlar os tiros do jogadores.
        int bala = 3;
        int bala2 = 2;

        int bala01 = 2;
        int bala02 = 1;

        int balaEspecial = 3;
        int balaEspecial2 = 2;

        int balaEspecial01 = 3;
        int balaEspecial02 = 2;

        int tamanhoDe20 = 20;
        int tamanhoDe50 = 50;
        int velocidadeBola = 3;
        int velocidadeBola2 = 3;
        int velocidadeBolaESPECIAL = 3;
        int velocidadeBolaESPECIAL2 = 3;
       
        int yDoJogador1 = 0;
        int yDojogador2 = 0;
        bool ativa = false;
        bool ativa2 = false;
        bool ativaEspecial = false;
        bool ativaEspecial2 = false;
        bool ativaVida = true;
        bool ativaVida2 = true;



        int paredex = 0;
        int paredey = 0;
        int xwall1()
        {
            return -400 / 2 + larguradoWall() / 2;
        }
        int xwall2()
        {
            return 400 / 2 - larguradoWall() / 2;
        }
        //tamanho
        int larguradoWall()
        {
            return tamanhoDe20;
        }
        int alturadoWall()
        {
            return 3 * tamanhoDe20;
        }

        int PosiçãoDoX1()
        {
             
            return 0;
        }int PosiçãoDoX2()
        {
             
            return -0;
        }
        int PosiçãoDoY1()
        {
            return 0;
        }int PosiçãoDoY2()
        {
            return -0;
        }


       
        
        protected override void OnUpdateFrame(FrameEventArgs A)
        {
            
            //dano
            //jogador 2
            if (bola2.x + tamanhoDe20 < somax && bola2.y - tamanhoDe20 < somay&&
                bola2.y + tamanhoDe20 > somay)
            {
                bola2.x = 250;
                bola2.y = 0;

                
                vida2--;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Dano Recebido,");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Vida [A]:{vida2}");
            }
         
            //jogador 1
           if (bola1.x - tamanhoDe20 > somax2 && bola1.y - tamanhoDe20 < somay2&&
                bola1.y + tamanhoDe20 > somay2)
            {
                
               bola1.x = -250;
               bola1.y = 0;

                vida1--;

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Dano Recebido,");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Vida [B]:{vida1}");



            }
            //dano do ESPECIAL 1
            if (bola2.x + tamanhoDe50 < spex && bola2.y - tamanhoDe50 < spey &&
               bola2.y + tamanhoDe50 > spey)
            {
                bola2.x = 250;
                bola2.y = 0;

                if(ativaVida == true)
                {
                    vida2 = vida2 - 4;

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Super Dano Recebido");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Vida [A]:{vida2}");

                    ativaVida = false;
                }
              
            }
            // dano do ESPECIAL 2
            if (bola1.x - tamanhoDe50 > spex2 && bola1.y - tamanhoDe50 < spey2 &&
              bola1.y + tamanhoDe50 > spey2)
            {

                bola1.x = -250;
                bola1.y = 0;

                if(ativaVida2 == true)
                {
                    vida1 = vida1 - 4;

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Dano Recebido,");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Vida [B]:{vida1}");

                    ativaVida2 = false;
                }



            }
            //vida jogador 2 
            if (vida2 <= 0)
            {
                pontos2++;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Jogador[B] Ganhou um ponto!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Pontos Jogador[B]:{pontos2}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Pontos Jogador[A]:{pontos}");
                vida1 = 0;
                vida2 = 0;

                vida2 = vida2 + 4;
                vida1 = vida1 + 4;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bala e Escudo Regenerados!");
                balaEspecial++;
                balaEspecial01++;
            }

            //vida jogador 1
            if (vida1 <= 0)
            {
                pontos++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Jogador[A] Ganhou um ponto!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Pontos Jogador[A]:{pontos}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Pontos Jogador[B]:{pontos2}");
                vida1 = 0;
                vida2 = 0;

                vida1 = vida1 + 4;
                vida2 = vida2 + 4;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Bala e Escudo Regenerados!");
                balaEspecial++;
                balaEspecial01++;
            }





            //if que se a bala chegar na borda ela vai resetar a posição dela e desativar o ativa.
            //  Console.WriteLine($"Bala :{bala}");
            if (somax < -ClientSize.Width / 2 || somax > ClientSize.Width / 2)
            {
                bala++;
                
                
                somax = 0;
                ativa = false;
            }
          
            velocidadeBola =  + 20;
            if (ativa == true)
            {
                somax = somax + velocidadeBola;

            }

            velocidadeBola2 = -20;
            if (ativa2 == true)
            {
                somax2 = somax2 + velocidadeBola2;
            }

            velocidadeBolaESPECIAL = 10;
            if (ativaEspecial == true)
            {
                spex = spex + velocidadeBolaESPECIAL;
            }

            velocidadeBolaESPECIAL2 = -10;
            if (ativaEspecial2 == true)
            {
                spex2 = spex2 + velocidadeBolaESPECIAL2;
            }



            //jogador 2
            if (Keyboard.GetState().IsKeyDown(Key.U) && bala01> bala02)
            {
                ativa2 = true;

                somax2 = PosiçãoDoX2() + bola2.x;
                somay2 = PosiçãoDoY2() + bola2.y;



                bala01--;

            }

            //if que ativa o bloco que sera criado e posicionado
            if (Keyboard.GetState().IsKeyDown(Key.E) && bala > bala2)
            {
                ativa = true;

                somax = PosiçãoDoX1() + bola1.x;
                somay = PosiçãoDoY1() + bola1.y;


                bala--;
            }

            //ESPECIAAAAL tiro especial....
            if (Keyboard.GetState().IsKeyDown(Key.F) && balaEspecial > balaEspecial2)
            {
                ativaEspecial = true;

                spex = PosiçãoDoX1() + bola1.x;
                spey = PosiçãoDoY1() + bola1.y;



                balaEspecial--;

            }
            //ESPECIIAAAAL DOIS 
            if (Keyboard.GetState().IsKeyDown(Key.H) && balaEspecial01 > balaEspecial02)
            {
                ativaEspecial2 = true;

                spex2 = PosiçãoDoX2() + bola2.x;
                spey2 = PosiçãoDoY2() + bola2.y;



                balaEspecial01--;

            }

            if (somax2 < -ClientSize.Width / 2 )
            {
                bala01++;


                somax2 = 0;
                ativa2 = false;
            }
           
           

            //verificar se a bala colidu com o wall 1
            if (somax - tamanhoDe20 / 2 < xwall1() + larguradoWall() / 2 &&
                 somax + tamanhoDe20 / 2 > xwall1() - larguradoWall() / 2 &&
                 somay + tamanhoDe20 / 2 > yDoJogador1 - alturadoWall() / 2 &&
                 somay - tamanhoDe20 / 2 < yDoJogador1 + alturadoWall() / 2 )
                
            {
                somax = 0;

                ativa = false;
                bala++;
            }

            if(somax + tamanhoDe20 / 2 > xwall2() - larguradoWall() / 2 &&
                somax - tamanhoDe20 / 2 < xwall2() + larguradoWall() / 2
                && somay + tamanhoDe20 / 2 > yDoJogador1 - alturadoWall() / 2 &&
                somay - tamanhoDe20 / 2 < yDojogador2 + alturadoWall() / 2)
            {
                somax = 0;

                ativa = false;
                bala++;
            }

            //verificar se a bala2 colidu com o wall 2
            if (somax2 - tamanhoDe20 / 2 < xwall1() + larguradoWall() / 2 &&
                 somax2 + tamanhoDe20 / 2 > xwall1() - larguradoWall() / 2 &&
                 somay2+ tamanhoDe20 / 2 > yDoJogador1 - alturadoWall() / 2 &&
                 somay2 - tamanhoDe20 / 2 < yDoJogador1 + alturadoWall() / 2)

            {
                somax2 = 0;

                ativa2 = false;
                bala01++;
            }

            if (somax2 + tamanhoDe20 / 2 > xwall2() - larguradoWall() / 2 &&
                somax2 - tamanhoDe20 / 2 < xwall2() + larguradoWall() / 2
                && somay2 + tamanhoDe20 / 2 > yDoJogador1 - alturadoWall() / 2 &&
                somay2 - tamanhoDe20 / 2 < yDojogador2 + alturadoWall() / 2)
            {
                somax2 = 0;

                ativa2 = false;
                bala01++;
            }

            //vai verificar se a bola esta colidindo com o wall do jogador 1
            if (bola1.x - tamanhoDe20 / 2 < xwall1() +     larguradoWall()/ 2 &&
                 bola1.y + tamanhoDe20 / 2 > yDoJogador1 - alturadoWall() / 2 &&
                 bola1.y - tamanhoDe20 / 2 < yDoJogador1 + alturadoWall() / 2 &&
                 bola1.x + tamanhoDe20 / 2 > xwall1() -    larguradoWall()/2)
            {
                //vai verificar se a bola esta colidindo com o wall do jogador 1
                if (Keyboard.GetState().IsKeyDown(Key.A))
                {


                    bola1.x = bola1.x + 4;




                }
                else
                {
                    bola1.x = bola1.x + 4;
                }

                if (Keyboard.GetState().IsKeyDown(Key.S))
                {
                    bola1.y = bola1.y + 4;


                }
                else
                {
                    bola1.y = bola1.y + 4;
                }

            }
            
            if (bola1.x - tamanhoDe20 / 2 < xwall1() +     larguradoWall()/ 2 &&
                 bola1.y + tamanhoDe20 / 2 > yDoJogador1 - alturadoWall() / 2 &&
                 bola1.y - tamanhoDe20 / 2 < yDoJogador1 + alturadoWall() / 2 &&
                 bola1.x + tamanhoDe20 / 2 > xwall1() -    larguradoWall()/2)
            {
                if (Keyboard.GetState().IsKeyDown(Key.D))
                {
                    bola1.x = bola1.x -8;

                    
                }
                else
                {
                    bola1.x = bola1.x - 4;
                }

                //arrumar esse if
                if (Keyboard.GetState().IsKeyDown(Key.W))
                {
                    bola1.y = bola1.y - 8;
                }
                else
                {
                    bola1.y = bola1.y - 4;
                }

            }
            if (bola2.x - tamanhoDe20 / 2 < xwall2() + larguradoWall() / 2 &&
                 bola2.y + tamanhoDe20 / 2 > yDoJogador1 - alturadoWall() / 2 &&
                 bola2.y- tamanhoDe20 / 2 < yDoJogador1 + alturadoWall() / 2 &&
                 bola2.x + tamanhoDe20 / 2 > xwall2() - larguradoWall() / 2)
            {
                //vai verificar se a bola esta colidindo com o wall do jogador 2
                if (Keyboard.GetState().IsKeyDown(Key.J))
                {


                    bola2.x = bola2.x + 4;




                }
                else
                {
                    bola2.x = bola2.x + 4;
                }

                if (Keyboard.GetState().IsKeyDown(Key.K))
                {
                    bola2.y = bola2.y + 4;


                }
                else
                {
                    bola2.y = bola2.y + 4;
                }

            }

            if (bola2.x - tamanhoDe20 / 2 < xwall2() + larguradoWall() / 2 &&
                 bola2.y + tamanhoDe20 / 2 > yDoJogador1 - alturadoWall() / 2 &&
                 bola2.y - tamanhoDe20 / 2 < yDoJogador1 + alturadoWall() / 2 &&
                 bola2.x + tamanhoDe20 / 2 > xwall2() - larguradoWall() / 2)
            {
                if (Keyboard.GetState().IsKeyDown(Key.L))
                {
                    bola2.x = bola2.x - 8;


                }
                else
                {
                    bola2.x = bola2.x - 4;
                }

                //arrumar esse if
                if (Keyboard.GetState().IsKeyDown(Key.I))
                {
                    bola2.y = bola2.y - 8;
                }
                else
                {
                    bola2.y = bola2.y - 4;
                }

            }


            //posição Y
            //esse ifs vão verificar se a bola esta colidindo com a parede de cima e de baixo
            if (bola1.y < -ClientSize.Height / 2 || bola1.y > ClientSize.Height / 2)
            {
                bola1.x = -250;
                bola1.y = 0;
            }
            if (bola2.y < -ClientSize.Height / 2 || bola2.y > ClientSize.Height / 2)
            {
                bola2.x = 250;
                bola2.y = 0;
            }

            //esse código vai verificar se a bola saiu da tela e vai resetar a posição dela
            if (bola1.x < -ClientSize.Width / 2 || bola1.x > ClientSize.Width / 2)
            {
                bola1.x = -250;
                bola1.y = 0;
            }
            if (bola2.x < -ClientSize.Width / 2 || bola2.x > ClientSize.Width / 2)
            {
                bola2.x = 250;
                bola2.y = 0;

            }

            //Colisão da bala especial
            if (spex < -ClientSize.Width / 2 || spex > ClientSize.Width / 2)
            {
                spex = 0;
                spey = 0;
                ativaEspecial = false;
                ativaVida = true;
            }
            if (spex2 < -ClientSize.Width / 2 || bola2.x > ClientSize.Width / 2)
            {
                spex2 = 0;
                spey2 = 0;
                ativaEspecial2 = false;

                ativaVida2 = true;
            }

            //Colisão da parede invisivel.
            if (bola1.x + tamanhoDe20 / 2 > paredex - alturadoWall() / 2)
            {
                if (Keyboard.GetState().IsKeyDown(Key.D))
                {
                    bola1.x = bola1.x - 8;
                }
            }
            if (bola2.x - tamanhoDe20 / 2 < paredex + alturadoWall() / 2)
            {
                if (Keyboard.GetState().IsKeyDown(Key.J))
                {
                    bola2.x = bola2.x + 8;
                }
            }






            //botoes
            //jogador 1
            if (Keyboard.GetState().IsKeyDown(Key.W))
            {
                bola1.y = bola1.y + 4;
            }

            if (Keyboard.GetState().IsKeyDown(Key.S))
            {
                bola1.y = bola1.y - 4;
            }

            if(Keyboard.GetState().IsKeyDown(Key.D))
            {
                bola1.x = bola1.x + 4;
            }

            if (Keyboard.GetState().IsKeyDown(Key.A))
            {
                bola1.x = bola1.x - 4;
            }
            //jogador2

            if (Keyboard.GetState().IsKeyDown(Key.I))
            {
                bola2.y = bola2.y + 4;
            }

            if (Keyboard.GetState().IsKeyDown(Key.K))
            {
                bola2.y = bola2.y - 4;
            }

            if (Keyboard.GetState().IsKeyDown(Key.L))
            {
                bola2.x = bola2.x + 4;
            }

            if (Keyboard.GetState().IsKeyDown(Key.J))
            {
                bola2.x = bola2.x - 4;
            }


            //koke tem nada aqui msm

            if (bola1.x + tamanhoDe20 / 2 > ClientSize.Width /2)
            {

            }



        }


        protected override void OnRenderFrame(FrameEventArgs E)
        {
            GL.Viewport(0, 0, ClientSize.Width, ClientSize.Height);
            
            Matrix4 projection = Matrix4.CreateOrthographic(ClientSize.Width, ClientSize.Height, 0.0f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);

            GL.Clear(ClearBufferMask.ColorBufferBit);
           GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
           
            //quadadadadadadado



            desenharquadrado(bola1.x, bola1.y, tamanhoDe20, tamanhoDe20, 1.0f, 1.0f, 0.0f);
            desenharquadrado(bola2.x, bola2.y, tamanhoDe20, tamanhoDe20, 1.0f, 0.4f, 0.0f);
            desenharquadrado(xwall1(), yDoJogador1, larguradoWall(),alturadoWall(), 0.0f, 0.0f, 1.0f);
            desenharquadrado(xwall2(), yDojogador2, larguradoWall(), alturadoWall(), 0.0f, 0.0f, 1.0f);
            //parede invisivel.
            desenharquadrado(paredex, paredey, larguradoWall(), 2222, 0.0f, 0.0f, 0.0f);

            //if que criara o bloco
            if (ativa == true)
            {
                
                
                desenharquadrado(somax, somay, tamanhoDe20, tamanhoDe20, 1.0f, 0.0f, 0.0f);
                
            }
            
            if (ativa2 == true)
            {
                

                desenharquadrado(somax2, somay2, tamanhoDe20, tamanhoDe20, 1.0f, 0.0f, 0.0f);
                
            }
           
         
            if(ativaEspecial == true)
            {
                desenharquadrado(spex, spey, tamanhoDe50, tamanhoDe50, 1.0f, 4.0f, 9.0f);
               
            }

            if (ativaEspecial2 == true)
            {
                desenharquadrado(spex2, spey2, tamanhoDe50, tamanhoDe50, 1.0f, 4.0f, 9.0f);

            }
            SwapBuffers();

            
            //vida jogador 2
           
        }


        
        void desenharquadrado(int x, int y, int largura, int altura, float r, float g, float b)
        {

            GL.Color3(r,g,b);

            GL.Begin(PrimitiveType.Quads);
            GL.Vertex2(-0.5f * largura + x, -0.5f * altura +  y);
            GL.Vertex2( 0.5f * largura + x, -0.5f * altura +  y);
            GL.Vertex2( 0.5f * largura + x,  0.5f * altura +  y);
            GL.Vertex2(-0.5f * largura + x,  0.5f * altura +  y);
            GL.End();
        }

        static Retangulo CriarRetangulo(int x, int y, int largura, int altura)
        {
            Retangulo R = new Retangulo();

            R.x = x;
            R.y = y;

            R.largura = largura;
            R.altura = altura;

            return R;
        }






        static void Main(string[] args)
        {
            Program l = new Program();
            l.bola2 = CriarRetangulo(0,0, 20, 20);
            l.bola1 = CriarRetangulo(0,0, 20, 20);

            l.Run();
            


        }
    }
}
