"use client"


import CarrousselImage from "./CarrousselImage"

export default  function Logement({Images, NomLogement, NbreAppDispo, NbreStdDispo,Adresse}){



    

    return (

        <div className="flex gap-5">
            
            <div>
                <CarrousselImage Pictures={Images}/>
            </div>


            <div className="flex-column ">

                <p className="text-xl"> {NomLogement}</p>
                <p lassName="text-xl"> {NbreAppDispo} apparrtements disponible</p>
                <p lassName="text-xl"> {NbreStdDispo} studio disponible</p>
                <p lassName="text-xl"> {Adresse}</p>
            </div>
        </div>
    )
}