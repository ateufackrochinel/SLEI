"use client";

import { useEffect, useState } from "react"
import { useRouter } from "next/navigation";
import { useSearchParams } from "next/navigation";
import Image from "next/image";
import { getLogements } from "./../Services/logement-api"
import Logement from "./Logement.jsx"


export default function ListeLogements(){

    const searchParams = useSearchParams();
    const routeur= useRouter();
    const [city, setCity] =useState(null);

    
    
 // const image = searchParams.get("image");

 const [logements, setLogements]=useState([])

  const imagesParVille = {
    Montréal: "/Images/Villes/montreal.jpeg",
    "Quebec city": "/Images/Villes/quebec_city.jpg",
    Sherbrooke: "/Images/Villes/sherbrooke.jpg",
    Chicoutimi: "/Images/Villes/chicoutimi.jpg",
    Longueil: "/Images/Villes/longueil.webp",
    Levis: "/Images/Villes/laval.webp",
  };

   

   useEffect(() => {

    const c= searchParams.get("city");
    setCity(c);
    if (c){
       console.log("La ville", city);
      getLogements(c).then(data=>{
    console.log(" les logements",data);
  setLogements(data);})
    }
  }, [searchParams]);


//    useEffect( ()=> {
   
//   getLogements(city).then(data=>{
//     console.log(" les logements",data);
//   setLogements(data);

  
// })
//   }, []);

  
  

  if (!city) return null;
  const imageurl = imagesParVille[city] 
 

// const router= useRouter();
// const { city, Image}= router.query
    return (
        
        <div suppressHydrationWarning>    
        <div className="relative"> 
        
                {imageurl && (

                    <Image src={imageurl} alt="Image de la ville "
                 width={1920}
                 height={100}
                 className="w-full h-[450px] object-cover"/>
                )}
                
                
                <div className=" absolute inset-0 mx-auto max-w-6xl px-4  py-25 gap-30">
        
                  
                <p className="text-white text-5xl"> {city}</p>
        
                </div>
        
              </div>

          <div className=" max-w-6xl mx-auto px-4 py-5 "> 
                 <p className="text-3xl  sm:text-5xl font-bold py-5"> Nos logements dans la ville de {city}</p>

                 
                <input
                  type="text"
                  placeholder="Entrez le nom d'une rue "/>

                  <div className="grid sm:grid-cols-1 md:grid-cols-2 gap-8"> 

                     { 
                      logements.map ( (logement =>

                        <Logement key= { logement.logementId} Images ={logement.images}  NomLogement={logement.nomLogement} NbreAppDispo={logement.nbreAppartement} NbreStdDispo={logement.nbreStudio} Adresse={logement.adreese} /> 
                      ))
                    } 


                    </div>
 


          </div>
        </div>
        
    );
}