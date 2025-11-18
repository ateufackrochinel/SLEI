

export async function getLogements( NomVille: string){

    const result = await fetch (`https://localhost:44384/api/Logement/ListeLogements?NomVille=${NomVille}`);

    if (!result.ok) {

        throw new Error ("Failed to fetch logements");
    }

return result.json();


}