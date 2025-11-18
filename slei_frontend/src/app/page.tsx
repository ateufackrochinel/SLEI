
import Image from "next/image";
import styles from "./page.module.css";
import Carroussel from "./Carroussel.jsx"
import Ville from "./Ville.jsx"



export default function Home() {

  const Images= [{id : 1, src :"/Images/im1.avif"}, {id : 2 , src: "/Images/im2.jpg"}, {id : 3, src :"/Images/im5.webp"}]
 // cont Villes= [{ id: 1, nom:"Montreal", src= }]
  return (
   <div>


    <main>

      <div className="relative"> 

        <Image src="/Images/image-quebec.jpg" alt="Image du Quebec "
         width={1920}
         height={100}
         className="w-full h-[450px] object-cover"/>
        
        <div className=" flex flex-col absolute inset-0 mx-auto max-w-6xl px-4  py-20 gap-30">

          <h1 className="text-white text-xl  sm:text-3xl md:text-5xl font-bold">
            Bienvenu sur SLEI
          </h1>
           <p className="text-white text-xl sm:text-3xl md:text-5xl"> Trouver votre logement dans la province du Quebec</p>

        </div>

      </div>

      <div className=" max-w-6xl mx-auto px-4 py-5 ">
          <p className="text-3xl  sm:text-5xl font-bold py-5"> Nos logements</p>
          <Carroussel  Images= {Images} />

          <p className=" text-3xl font-bold py-5"> Choisissez une ville et trouver le logement de vos reves </p>

          <div className="grid sm:grid-cols-2 md:grid-cols-3 gap-8"> 

            <Ville NomVille="Montréal" ImageUrl="/Images/Villes/montreal.jpeg"/>
            <Ville NomVille="Quebec city" ImageUrl="/Images/Villes/quebec_city.jpg"/>
            <Ville NomVille="Sherbrooke" ImageUrl="/Images/Villes/sherbrooke.jpg"/>
            <Ville NomVille="Chicoutimi" ImageUrl="/Images/Villes/chicoutimi.jpg"/>
            <Ville NomVille="Longueil" ImageUrl="/Images/Villes/longueil.webp"/>
            <Ville NomVille="Levis" ImageUrl="/Images/Villes/laval.webp"/>
            
                         
          </div>

      </div>
          
      </main>    
   </div>
  );
}
