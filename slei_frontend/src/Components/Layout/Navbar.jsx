import Link from "next/link";
export default function Navbar(){

    return (

       <nav className="mx-auto max-w-6xl py-5 bg-blue-600 px-4">

        <div className="flex justify-between " > 
            <div className="font-bold text-white text-lg"> <Link href="/"> SLEI</Link> </div>
        <ul className="flex gap-6 text-white">
            <li><a href="/Login" className=" hover:text-blue-400  text-lg">Se Connecter</a></li>
            <li><a href="/SingUp" className="hover:text-blue-400  text-lg">S'inscrire</a></li>
            <li><a href="/about" className="hover:text-blue-400  text-lg">A propos</a></li>
         </ul>
        </div>

</nav>

    );
}