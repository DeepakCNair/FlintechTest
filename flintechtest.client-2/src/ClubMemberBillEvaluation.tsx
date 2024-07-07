import { Component } from 'react';
import { ClubMemberState } from './Interfaces/ClubMemberState';
import { ClubMember } from './Interfaces/ClubMember';

class ClubMemberBillEvaluation extends Component<{}, ClubMemberState> {

    constructor(props: {}) {
        super(props);
        this.state = {
            clubMembers: [{
                "id": 1,
                "name" : "member A",
                "linkId": 3,
            },
            {
                "id": 2,
                "name": "member B",
                "linkId": 1,
            },
            {
                "id": 3,
                "name": "member C",
                "linkId": 2
            },
            {
                "id": 4,
                "name": "member D",
                "linkId": null
            },
            {
                "id": 5,
                "name": "member E",
                "linkId": null
            },
            {
                "id": 6,
                "name": "member F",
                "linkId": 1
            },
            {
                "id": 7,
                "name": "member G",
                "linkId": 9
            },
            {
                "id": 8,
                "name": "member H",
                "linkId": 9
            },
            {
                "id": 9,
                "name": "member I",
                "linkId": null
            },
            {
                "id": 10,
                "name": "member J",
                "linkId": 10
            },
            {
                "id": 11,
                "name": "member K",
                "linkId": null
            }]            
        };
    }

    runBilling = () => {
        for (let i = 0; i < this.state.clubMembers.length; i++) 
        {
            let node : ClubMember = this.state.clubMembers[i];
            this.evaluateParentNode(i, node);

            this.updateNode(i, node);
        }
    }

    evaluateParentNode = (nodeIndex : number, currentNode : ClubMember) => 
    {
        if (this.isFalse(currentNode.isTraversed) === false)
        {
            currentNode.isTraversed = true;
            this.updateNode(nodeIndex, currentNode);

            if (currentNode.linkId === null) {
                currentNode.isBillable = true;
                this.updateNode(nodeIndex, currentNode);

                return;
            }
            else if (currentNode.id === currentNode.linkId) 
            {
                currentNode.isCircularReference = true;
                this.updateNode(nodeIndex, currentNode);

                return;
            }
            else {
                let parentNode = this.state.clubMembers.filter(clubMember => clubMember.id === currentNode.linkId);
                let parentNodeIndex = this.state.clubMembers.findIndex(clubMember => clubMember.id === currentNode.linkId);

                if (parentNode != null && parentNodeIndex >= 0) {
                    this.evaluateParentNode(parentNodeIndex, parentNode[0]);
                }
            }
        }
        else {
            currentNode.isCircularReference = true;
            this.updateNode(nodeIndex, currentNode);

            return;
        }
    }

    updateNode = (nodeIndex : number, node : ClubMember) => {
        let clubMembers : ClubMember[] = this.state.clubMembers;
        clubMembers[nodeIndex] = node;

        this.setState({ clubMembers: clubMembers });
    }

    componentDidMount() {
        console.log('Club Member Bill Evaluation mounted'); 

        this.runBilling();
    }

    isFalse = (obj : any) => {
        if (obj === undefined) {
            return false;
        }
        else if (obj === null) {
            return false;
        }
        else if (Boolean(obj).valueOf() === false) {
            return false
        }

        return true;
    }

    render() {
        return (
            <div>
                
            </div>
        );
    }
}

export default ClubMemberBillEvaluation;