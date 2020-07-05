class VeterinaryClinic {
    
    constructor(clinicName, capacity){
       this.clinicName = clinicName;
       this.capacity = capacity;
       this.clients =[];
      // this._clientPetsDictionary={};
       this.totalProfit =0;
       this.currentWorkload =0;
    }

    newCustomer(ownerName, petName, kind, procedures){

        if(this.capacity===this.clients.length-1){
            throw new Error(`Sorry, we are not able to accept more patients!`);
        }
        
        if(this.clients.some(c => c.toLowerCase() === ownerName.toLowerCase())){// OWNER
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`)
        }else{
            this.clients.push(ownerName);
        }

        if(true){// Pet
            console.log(this.clients[ownerName][petName]);
            if(this.clients[ownerName][petName].length>0){
                result = (`This pet is already registered under ${ ownerName } name! ${ petName } is on our lists, waiting for `);
                result+= this.clients[ownerName][petName].join(', ');
                throw new Error(result);
            }
            
        }else{
            this.clients[ownerName].push(petName);
            this.clients[ownerName][petName].push(...procedures);
            this.capacity++;
            return `Welcome ${ petName }!`;
        }


    }

    onLeaving (ownerName, petName) {

    }
}

let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B'])); 
