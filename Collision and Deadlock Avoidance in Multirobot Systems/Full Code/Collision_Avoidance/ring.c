 
#ifdef REAL
#include <kilolib.h>
#include "ring.h"
#include <time.h>
USERDATA myData;
USERDATA *mydata = &myData;
#else
#include <math.h>
//#include <kilombo.h>
#include <stdio.h> 
#include "ring.h"
#include <time.h>
REGISTER_USERDATA(USERDATA)
#endif

uint16_t count=0;
uint8_t sem=0;
void send_election();
void prepare_message(uint8_t m, uint8_t receiver);
void smooth_set_motors(uint8_t ccw, uint8_t cw)
{
    set_motors(ccw, cw);
}


void set_motion(motion_t new_motion)
{
    switch(new_motion) {
        case STOP:
            smooth_set_motors(0,0);
            break;
        case FORWARD:
            smooth_set_motors(kilo_turn_left, kilo_turn_right);
            break;
        case LEFT:
            smooth_set_motors(kilo_turn_left, 0);
            break;
        case RIGHT:
            smooth_set_motors(0, kilo_turn_right);
            break;
    }
}

void message_rx(message_t *m, distance_measurement_t *d)
{
    uint8_t distance = estimate_distance(d);
    uint8_t minimum_distance = 70;
    uint8_t closest_distance = 25;
    mydata->counter=0;
    mydata->distance= distance;    
    if(distance > closest_distance)
    {
    if(distance < minimum_distance && (mydata->my_id < m->data[ID])) 
    {
        mydata->motion_state=DISABLED;
    }
    else 
    {
        mydata->motion_state=ACTIVE;
    }
    }
    
    if (distance <= closest_distance && (mydata->my_id < m->data[ID])){
        mydata->motion_state=ACTIVE;
    }
    else if (distance <= closest_distance && (mydata->my_id > m->data[ID])){
        mydata->motion_state=DISABLED;
    }

}


void prepare_message(uint8_t m, uint8_t receiver)
{
    mydata->msg.data[MSG] = m;
    mydata->msg.data[ID] = mydata->my_id;
    mydata->msg.data[MOTION_STATE] = mydata->motion_state;
    mydata->msg.data[RECEIVER] = mydata->my_right;
    mydata->msg.data[SENDER] = mydata->my_id;
    mydata->msg.data[STATE] = mydata->state;
    mydata->msg.data[LEADER]=mydata->my_leader;
    mydata->msg.data[COLOR]=mydata->my_color; 
    mydata->msg.data[RANDOM_VALUE]=mydata->my_random_value;
    mydata->msg.type = NORMAL;
    mydata->msg.crc = message_crc(&mydata->msg);
    mydata->message_sent = 0;
}

void send_sharing()
{
    mydata->counter++;
    if (mydata->now >= mydata->next_share_sending &&  mydata->message_sent == 1)
    {
        prepare_message(SHARE, 0);
        mydata->next_share_sending = mydata->now + SHARING_TIME;
    }
}



void move(uint8_t tick)
{
	if(mydata->motion_state != DISABLED) {
		if (mydata->time_active < mydata->move_motion[mydata->move_state].time)
		{
		    delay(1000);
		    set_motion(mydata->move_motion[mydata->move_state].motion);
		    mydata->time_active++;
		}
		else{
		    mydata->move_state=1-mydata->move_state;
		    mydata->time_active=0;
		}	
	} else {
		set_motion(STOP);	
	}		
}

void resume()
{   if(mydata->counter > 35){
    mydata->counter=0;
    mydata->motion_state=ACTIVE;
    }
    
}

void bot_color(){
    if (mydata->motion_state == ACTIVE){
        mydata->red=0;
        mydata->green=1;
        mydata->blue=0;
    }
    if (mydata->motion_state == DISABLED){
        mydata->red=1;
        mydata->green=0;
        mydata->blue=0;
    }
    
    
}

void loop()
{
    if(mydata->state!=DEACTIVATED)
    {
    delay(30);
    
    send_sharing();
    move(mydata->now);
    resume();
    bot_color();
    set_color(RGB(mydata->red, mydata->green, mydata->blue));
    
    mydata->now++;
    }
    
}


message_t *message_tx()
{
    return &mydata->msg;
}

void message_tx_success() {
    mydata->message_sent = 1;
    mydata->msg.data[MSG] = NULL_MSG;
    mydata->msg.crc = message_crc(&mydata->msg);
}


void setup() {
    rand_seed(rand_hard());
    mydata->my_id = rand_soft();
    mydata->my_color = mydata->my_id; 
    mydata->my_random_value=rand_soft();
    mydata->state = COOPERATIVE;
    mydata->my_left = mydata->my_right = mydata->my_id;
    mydata->my_left_color = mydata->my_right_color = mydata->my_id;
    mydata->num_neighbors = 0;
    mydata->message_sent = 0,
    mydata->now = 0,
    mydata->next_share_sending = SHARING_TIME;
    mydata->next_wakeup = WAKEUPTIME;
    mydata->next_mis = MISTIME;
    mydata->next_stabilization = STABILIZATIONTIME;
    mydata->cur_motion = STOP;
    mydata->motion_state = ACTIVE;
    mydata->time_active = 0;
    mydata->move_state = 0;
    mydata->move_motion[0].motion = FORWARD;
    mydata->move_motion[0].time = 250;
    mydata->move_motion[1].motion = RIGHT;
    mydata->move_motion[1].time = 330;
    mydata->counter = 0;
    mydata->red = 0,
    mydata->green = 0,
    mydata->blue = 0,
    mydata->send_election = 1;
    mydata->is_leader = 0;
    mydata->my_leader = mydata->my_id;
    mydata->active = 0;
    
    mydata->msg.data[MSG] = NULL_MSG;
    mydata->msg.crc = message_crc(&mydata->msg);
    
    
    
#ifdef SIMULATOR
    printf("Initializing %d\n", mydata->my_id);
#endif
    mydata->message_sent = 1;
}

#ifdef SIMULATOR
static char botinfo_buffer[10000];
char *cb_botinfo(void)
{
    char *p = botinfo_buffer;
    p += sprintf (p, "ID: %d \n", kilo_uid);
    if (mydata->state == COOPERATIVE)
        p += sprintf (p, "State: COOPERATIVE\n");
    if (mydata->state == AUTONOMOUS)
        p += sprintf (p, "State: AUTONOMOUS\n");
    
    return botinfo_buffer;
}
#endif

int main() {
    kilo_init();
    kilo_message_tx = message_tx;
    kilo_message_tx_success = message_tx_success;
    kilo_message_rx = message_rx;
    kilo_start(setup, loop);
    
    return 0;
}
