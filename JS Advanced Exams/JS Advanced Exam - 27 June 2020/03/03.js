class VeterinaryClinic {
    constructor(clinicName, capacity){
        this.clinicName = clinicName;
        this.capacity = capacity;
        this.clients = [];
        this.totalProfit = 0;
        this.currentWorkload = 0;
    }

    newCustomer(ownerName, petName, kind, procedures){

        if(this.currentWorkload === this.capacity){
            throw new Error("Sorry, we are not able to accept more patients!");
        }

        let client = this.clients.find(c => c.ownerName === ownerName);
        let newPet = {
            petName: petName,
            kind: kind.toLowerCase(),
            procedures: procedures
        };

        if(client !== undefined){
            let pet = client.pets.find(p => p.petName === petName);
            if(pet !== undefined && pet.procedures.length > 0){
                throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${pet.procedures.join(", ")}.`);
            }
            else if(pet !== undefined && pet.procedures.length === 0){
                pet.procedures = procedures;
                this.currentWorkload++;
                return `Welcome ${petName}!`;
            }
            else{
                client.pets.push(newPet);  
                this.currentWorkload++;             
                return `Welcome ${petName}!`;
            }
        }
        else{
            let newClient = {
                ownerName: ownerName,
                pets: [newPet]
            }
            this.clients.push(newClient);
            this.currentWorkload++; 
            return `Welcome ${petName}!`;
        }
    }

    onLeaving (ownerName, petName) {
        let client = this.clients.find(c => c.ownerName === ownerName);

        if(client === undefined){
            throw new Error("Sorry, there is no such client!");
        }

        let pet = client.pets.find(p => p.petName === petName);

        if(pet === undefined || pet.procedures.length === 0){
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        let profit = pet.procedures.length * 500;
        this.totalProfit += profit;
        this.currentWorkload--;
        pet.procedures = [];
        return `Goodbye ${petName}. Stay safe!`;
    }

    toString (){
        let percentage = Math.round(this.currentWorkload/this.capacity * 100);
        let result = [
            `${this.clinicName} is ${percentage}% busy today!`,
            `Total profit: ${this.totalProfit.toFixed(2)}$`
        ];

        this.clients.sort((a, b) => a.ownerName.localeCompare(b.ownerName));

        this.clients.forEach(client => {
            result.push(`${client.ownerName} with:`)
            client.pets.sort((a, b) => a.petName.localeCompare(b.petName));
            client.pets.forEach(pet => {
                result.push(`---${pet.petName} - a ${pet.kind.toLowerCase()} that needs: ${pet.procedures.join(", ")}`);
            });
        });

        return result.join("\n");
    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B'])); 
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']); 
console.log(clinic.toString());