"use client";

import Image from "next/image"
import { useRouter } from "next/navigation";
import Link from "next/link";

export default function Ville({NomVille, ImageUrl}){

    const router=useRouter();
    
    const  handleClick = (e)=> {

         e.preventDefault();

        router.push(`/ListeLogements?city=${encodeURIComponent(NomVille)}`);

       
    }

    return(
        
        <div className="relative"> 
        
             

           <Image src={ImageUrl} alt="Image de ville" 
           width={1920} 
           height={600}
           className="w-full h-[250px] object-cover"
           /> 
         
            <div className="absolute mx-auto inset-0 py-10 px-5"> 
                <p className="text-white">  <Link href="" className="text-3xl " onClick={handleClick}>  { NomVille } </Link></p>
                
            </div> 
        </div>
    );
}